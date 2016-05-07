using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	void Update () 
	{
		if (transform.position.z <= -20)
		{
			Destroy(gameObject);
		}
	}
}