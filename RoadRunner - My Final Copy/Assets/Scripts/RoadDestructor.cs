using UnityEngine;
using System.Collections;

public class RoadDestructor : MonoBehaviour {
	void Update () {
		if (transform.position.z <= -170) {
			transform.position = new Vector3(0f, 0f, 720.0f);
		}
	}
}
