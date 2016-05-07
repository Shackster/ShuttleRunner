using UnityEngine;
using System.Collections;

public class Gatescript : MonoBehaviour {
	
	//public GameControlScript control;
	public float objectSpeed = -0.5f;
	
	void Update () {
		if(Time.timeScale==1){
			transform.Translate(0, 0, objectSpeed);
		}
	}
}