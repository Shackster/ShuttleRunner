using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {
	
	public GUISkin skin;
	public GUISkin myskin;  //custom GUIskin reference
	public GUISkin start1;
	public Texture pic1;
	public GUISkin start2;	
	public GUISkin start3;
	float timeRemaining = 10f;
	float timeExtension = 3f;
	float timeDeduction = 5f;
	float totalTimeElapsed = 0f;
	float itemtime = 0f;
	float newspeed = 0f;
	float energy = 15f;
	public int speedstate = 1;
	float score=0f;
	bool bussed = false;
	bool itemized = false;
	bool speedchange = false;
	bool allowspd = true;
	public float busspd;
	public AudioSource coinSound;
	public AudioClip Csound;
	public AudioSource punchSound;
	public AudioClip Psound;
	public AudioSource pnorm;
	public AudioSource pup;
	public AudioSource pdown;
	public AudioClip cnorm;
	public AudioClip cup;
	public AudioClip cdown;
	public AudioSource newsource;
	public AudioClip newclip;
	public int busstops = 10;
	public bool isGameOver = false;
	public bool started = false;
	public static float worldspeeds;
	public bool slowed = false;
	public bool speeded = false;
	public static float respawnCycle = 6;
	public int currlvl = 0;
	void Start(){
		Time.timeScale = 1;  // set the time scale to 1, to start the game world. This is needed if you restart the game from the game over menu
		worldspeeds = 0.5f;
		speedstate = 1;
		itemized = false;
		speedchange = false;
		allowspd = true;
		energy = 7;
	}

	void Update () 
	{
		respawnCycle = worldspeeds * 12f;
		if(isGameOver)
			return;
		/*if(slowed && (worldspeeds < 0.5f))
		{
			worldspeeds += Time.deltaTime;
			if(worldspeeds > 0.5f)
			{
				worldspeeds = 0.05f;
			}
		}*/
		busstops = busstops;
		totalTimeElapsed += Time.deltaTime;
		if (speedchange) {
			itemtime += Time.deltaTime;
			if (itemtime < 8) {
				worldspeeds = newspeed;
				allowspd = false;
			} 
			else {
				itemtime = 0f;
				worldspeeds = 0.5f;
				speedchange = false;
				allowspd = true;
				speedstate = 1;
				pnorm.PlayOneShot (cnorm, 1.0f);
			}
		} 
		/*
		if ((speedstate == 1)) {
			pup.
		} 
		else if (speedstate == 2) {
		} 
		else if (speedstate == 3) {
		}*/
		score = totalTimeElapsed*100;
		timeRemaining -= Time.deltaTime;
		energy -= 2.5f * Time.deltaTime;
		/*if (speeded) {
			worldspeeds = 2.0f;
		}*/
		/*if (slowed) {
			worldspeeds = 0.5f;
		}*/
		if(energy <= 0)
		{
			isGameOver = true;
		}
		if(bussed)
		{
			isGameOver = true;
		}
		if (busstops == 0) {
			isGameOver = true;
		}
	}
	
	public void PowerupCollected()
	{
		//timeRemaining += timeExtension;
		energy += 2;
		speeded = true;
		slowed = false;
		coinSound.PlayOneShot(Csound, 0.8f);
	}
	public void Tire()
	{
		punchSound.PlayOneShot(Psound, 0.8f);
		energy -= 10f;
	}
	public void Push()
	{
		//timeRemaining += timeExtension;
		energy -= 0.05f;
		speedstate = 2;
		newspeed = -2.0f;
		speedchange = true;
		speedstate = 3;
	}
	public void BusStopped()
	{
		busstops = busstops - 1;
	}
	public void Hit()
	{
		punchSound.PlayOneShot(Psound, 0.8f);
		isGameOver = !isGameOver;
	}
	public void AlcoholCollected()
	{
		timeRemaining -= timeDeduction;
		speeded = false;
		slowed = true;
		speedstate = 3;
		newspeed = 0.1f;
		if (allowspd) {
			allowspd = false;
			speedchange = true;
			speedstate = 3;
			pnorm.Stop ();
			pdown.PlayOneShot (cdown, 0.8f);
		}
	}
	public void SkateCollected()
	{
		speeded = true;
		slowed = false;
		//currspeed = currspeed * 2;   //add time to the time remaining
	}
	public void SBCollected()
	{
		speeded = true;
		slowed = false;
		newspeed = 1.0f;
		if (allowspd) {
			allowspd = false;
			speedchange = true;
			speedstate = 2;
			pnorm.Stop ();
			pup.PlayOneShot (cup, 0.8f);
		}
		//currspeed = currspeed * 2;   //add time to the time remaining
	}
	public void BusCaught()
	{
		isGameOver = true;
		bussed = true;
	}
	public float BusSpeed()
	{
		if (speedstate == 1) {
			busspd = worldspeeds;
		} else if (speedstate == 2) {
			busspd = worldspeeds * 2.2f;
		} else if (speedstate == 3) {
			busspd = worldspeeds * -2.0f;
		}
		return busspd;
	}
	public float WorldSpeed()
	{
		return worldspeeds;
	}
	void OnGUI()
	{
		GUI.skin=skin; //use the skin in game over menu
		//check if game is not over, if so, display the score and the time left	private void OnGUI()
		if (!started) {
			Time.timeScale = 0;
			//	GUI.skin=myskin;   //use the custom GUISkin
					GUI.Box(new Rect(Screen.width, Screen.height, Screen.width, Screen.height), "START");
					//GUI.Label(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "YOUR SCORE: "+ ((int)score));
			GUI.DrawTexture(new Rect(25,25,25,25), pic1, ScaleMode.ScaleToFit, true, 10.0f);

					if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "START")){
						started = true;
					}
/*
					if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
						Application.LoadLevel(Application.loadedLevel);
					}
					
					if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
						Application.LoadLevel(levelToLoad);
					}*/
				}
		if(!isGameOver)   
		{
			GUI.Label(new Rect(10, 10, Screen.width/5, Screen.height/6),"ENERGY: "+((int)energy).ToString());
			//GUI.Label(new Rect(100, 200, Screen.width/5, Screen.height/6),"ITT: "+((float)itemtime).ToString());
			GUI.Label(new Rect(50, 100, Screen.width/5, Screen.height/6),"STOPS: "+((int)busstops).ToString());
			GUI.Label(new Rect(Screen.width-(Screen.width/6), 80, Screen.width/6, Screen.height/6), "SCORE: "+((int)score).ToString());
		}
		//if game over, display game over menu with score
		else
		{
			Time.timeScale = 0; //set the timescale to zero so as to stop the game world
			
			//display the final score
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "GAME OVER\nYOUR SCORE: "+(int)score);
			
			//restart the game on click
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}

			if ((GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "NEXT LEVEL")) && (currlvl < 6)){
				currlvl += 1;
				respawnCycle -= 1;
				energy -= 3;
				if (Application.loadedLevelName == "Fgame - lvl 1")
				{
					GetComponent<SpawnPedestrian>().enabled = true;
					Application.LoadLevel ("Fgame - lvl 2");
				}
				else if (Application.loadedLevelName == "Fgame - lvl 2")
				{
					GetComponent<SpawnGate>().enabled = true;
					Application.LoadLevel ("Fgame - lvl 3");
				}
				else if (Application.loadedLevelName == "Fgame - lvl 3")
				{
					GetComponent<SpawnPowerline>().enabled = true;
					GetComponent<SpawnBarricade>().enabled = true;
					Application.LoadLevel ("Fgame - lvl 4");
				}
				else if (Application.loadedLevelName == "Fgame - lvl 4")
				{
					GetComponent<SpawnCar>().enabled = true;
					Application.LoadLevel ("Fgame - lvl 5");
				}
				else if (Application.loadedLevelName == "Fgame - lvl 5")
				{
					GetComponent<SpawnBarrel>().enabled = true;
					Application.LoadLevel ("Fgame - lvl 6");
				}
			}
			//exit the game
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "EXIT GAME")){
				Application.Quit();
			}
		}
	}
}


