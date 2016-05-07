using UnityEngine;
using System.Collections;

public class SpawnHole : MonoBehaviour {
	public GameObject ManHole;
	float timeElapsed = 0;
	float spawnCycle = 2.0f;
	void Update () 
	{
		timeElapsed += Time.deltaTime;
		if(timeElapsed > (spawnCycle))
		{
			GameObject temp2;
			temp2 = (GameObject)Instantiate(ManHole);
			Vector3 pos = temp2.transform.position;
			temp2.transform.position = new Vector3((Random.Range(-3, 4) - 19), pos.y, (pos.z + 200));
			timeElapsed -= spawnCycle;
		}
	}
}
