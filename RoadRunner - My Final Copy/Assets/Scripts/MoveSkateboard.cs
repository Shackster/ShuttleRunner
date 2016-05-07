using UnityEngine;
using System.Collections;

public class MoveSkateboard : MonoBehaviour {
	public float objectSpeed = -0.5f;
	// Update is called once per frame
		void Update() {
		if(Time.timeScale==1){
			transform.Translate(0, 0, objectSpeed);
		}
	}
}
