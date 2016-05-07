using UnityEngine;
using System.Collections;

public class MoveRamp : MonoBehaviour {
	void Update () {
		float getWorldspeeds = (GameControlScript.worldspeeds);
		if(Time.timeScale==1){
			transform.eulerAngles = new Vector3(0, 0, getWorldspeeds);
			transform.Translate(0, 0, (-getWorldspeeds));
			transform.Rotate(335,0,0);
		}
	}
}
