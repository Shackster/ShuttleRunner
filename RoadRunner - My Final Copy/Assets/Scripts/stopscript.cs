using UnityEngine;
using System.Collections;

public class stopscript : MonoBehaviour {
	
	//public GameControlScript control;
	public float objectSpeed = -0.5f;
	
	
	void Update () {
		float getWorldspeeds = (-GameControlScript.worldspeeds);
		if(Time.timeScale==1){
			transform.Translate((getWorldspeeds), 0, 0);
		}
	}
}