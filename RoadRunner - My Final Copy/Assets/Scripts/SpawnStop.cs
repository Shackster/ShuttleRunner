using UnityEngine;
using System.Collections;

public class SpawnStop : MonoBehaviour {
	public GameObject MiniStop;
	float timeElapsed = 0;
	float spawnCycle = 5.0f;
	void Update () 
	{
		timeElapsed += Time.deltaTime;
		if(timeElapsed > (spawnCycle))
		{
			GameObject temp2;
			temp2 = (GameObject)Instantiate(MiniStop);
			Vector3 pos = temp2.transform.position;
			temp2.transform.position = new Vector3( -94f, 0f, (pos.z + 200));
			timeElapsed -= spawnCycle;
		}
	}
}