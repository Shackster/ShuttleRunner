using UnityEngine;
using System.Collections;

public class SpawnBarrel : MonoBehaviour {
	public GameObject Barrel;
	float timeElapsed = 0;
	float spawnCycle = 2.0f;
	void Update () 
	{
		timeElapsed += Time.deltaTime;
		if(timeElapsed > (spawnCycle))
		{
			GameObject temp2;
			temp2 = (GameObject)Instantiate(Barrel);
			Vector3 pos = temp2.transform.position;
			temp2.transform.position = new Vector3((Random.Range(-3, 4)), pos.y, (pos.z + 200));
			timeElapsed -= spawnCycle;
		}
	}
}
