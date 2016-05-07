using UnityEngine;
using System.Collections;

public class SpawnChair : MonoBehaviour {

	public GameObject Chair;
	float timeElapsed = 0;
	float spawnCycle = 1.5f;
	int spawnPlace = 0;
	void Update () 
	{
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp1;
			temp1 = (GameObject)Instantiate(Chair);
			Vector3 pos = temp1.transform.position;
			temp1.transform.position = new Vector3( -6, pos.y, (pos.z + 200));
			GameObject temp2;
			temp2 = (GameObject)Instantiate(Chair);
			Vector3 pos2 = temp1.transform.position;
			temp2.transform.position = new Vector3( 6, pos2.y, (pos2.z + 200));
			timeElapsed -= spawnCycle;
		}
	}
}
