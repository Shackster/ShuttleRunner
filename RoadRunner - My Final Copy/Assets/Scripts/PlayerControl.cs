using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameControlScript control;
	CharacterController controller;
	bool isGrounded= false;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	public 
	
	//start
	void Start () {
		controller = GetComponent<CharacterController>();
		//GetComponent<Animation> () ["run"].speed = (GameControlScript.worldspeeds);
	}
	
	// Update is called once per frame
	void Update (){
		if (transform.position.z != -7f) {
			Vector3 pos2 = transform.position;
			transform.position = new Vector3 (pos2.x, pos2.y, -7f);
		}
		float animationSpeed = (GameControlScript.worldspeeds);
		GetComponent<Animation> () ["run"].speed = (GameControlScript.worldspeeds) * 2f;
		if (controller.isGrounded) {
			GetComponent<Animation>().Play("run");

			//play "run" animation if spacebar is not pressed
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);  //get keyboard input to move in the horizontal direction
			moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
			moveDirection *= speed;            //increase the speed of the movement by the factor "speed"
			if (Input.GetAxis ("Vertical") > 0)
			{
				control.Push();
			}
			if (Input.GetButton ("Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed
				GetComponent<Animation>().Stop("run");
				GetComponent<Animation>().Play("jump_pose");
				moveDirection.y = jumpSpeed;         //add the jump height to the character
			}
			if(controller.isGrounded)           //set the flag isGrounded to true if character is grounded
				isGrounded = true;
		}
		
		moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity 
		controller.Move(moveDirection * Time.deltaTime);      //Move the controller
	}
	
	//check if the character collects the powerups or the snags
	void OnTriggerEnter(Collider other)
	{              
		if (other.gameObject.name == "Coin(Clone)") 
		{
			control.PowerupCollected ();
		} 
		else if (other.gameObject.name == "SkateB(Clone)") 
		{
			control.SBCollected ();
		} 
		else if (other.gameObject.name == "Skate(Clone)") 
		{
			control.SkateCollected ();
		} 
		else if (other.gameObject.name == "Barricade(Clone)") 
		{
			control.Hit();
		} 
		else if (other.gameObject.name == "Barrel(Clone)") 
		{
			control.Tire();
			control.AlcoholCollected();
		} 
		else if (other.gameObject.name == "Gate(Clone)") 
		{
			control.Hit();
		}
		else if (other.gameObject.name == "Car(Clone)") 
		{
			control.Hit();
		}
		else if(other.gameObject.name == "Pedestrian(Clone)")
		{
			control.Tire();
		}
		else if(other.gameObject.name == "Obstacle(Clone)" && isGrounded == true)
		{
			control.AlcoholCollected();
		}
		else if(other.gameObject.name == "BusStopA(Clone)" && isGrounded == true)
		{
			control.BusStopped();
		}
		else if(other.gameObject.name == "Bus")
		{
			control.BusCaught();
			Destroy(other.gameObject);
			control.isGameOver = true;
		}
		Destroy(other.gameObject);
	}
}