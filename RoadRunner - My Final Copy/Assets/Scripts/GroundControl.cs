using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {
	void Update () {
		float getWorldspeeds = (GameControlScript.worldspeeds);
		if(Time.timeScale==1){
			transform.Translate(0, (getWorldspeeds), 0);
		}
	}
}