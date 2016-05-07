using UnityEngine;
using System.Collections;

public class BusScript : MonoBehaviour {
	public GameControlScript controller;
	public float objectSpeed = 100.1f;
	public float speedMod = 0.5f;
	void Update () {
		transform.Translate((controller.BusSpeed() * (-0.2f * 0.1f)), -(controller.BusSpeed() * 0.1f), 0);
	}
}
