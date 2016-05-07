using UnityEngine;
using System.Collections;

public class SpawnPedestrian : MonoBehaviour {
	public GameObject Pedestrian;
	float timeElapsed = 0;
	float spawnCycle = 1.5f;
	int spawnPlace = 0;
	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp1;
			temp1 = (GameObject)Instantiate(Pedestrian);
			Vector3 pos = temp1.transform.position;
			spawnPlace = Random.Range(1, 3);
			temp1.transform.position = new Vector3(Random.Range(-6, 10), pos.y, pos.z);
			timeElapsed -= spawnCycle;
		}
	}
}
