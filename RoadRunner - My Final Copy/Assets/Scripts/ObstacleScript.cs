using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	
	//public GameControlScript control;
	public float objectSpeed = -0.25f;

	
	void Update () {
		float getWorldspeeds = (-GameControlScript.worldspeeds);
		if(Time.timeScale==1){
			transform.Translate(0, (getWorldspeeds), 0);
		}
	}
}