using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {
	float spin = 0f;
	void Update () {
		spin += (50 * (Time.deltaTime * 10));
		float getWorldspeeds = (-GameControlScript.worldspeeds);
		transform.eulerAngles = new Vector3(0, 0, getWorldspeeds);
		transform.Translate(0, 0, getWorldspeeds);
		transform.Rotate(0,spin,0);
	}
}