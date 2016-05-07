using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {
	void Update () {
		float getWorldspeeds = (GameControlScript.worldspeeds);
		if(Time.timeScale==1){
			transform.Translate(0, 0, ((getWorldspeeds)*(0.2f)));
		}
	}
}
