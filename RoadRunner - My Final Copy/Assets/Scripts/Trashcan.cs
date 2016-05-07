using UnityEngine;
using System.Collections;

public class Trashcan : MonoBehaviour {
	public GameObject Trashcan1;
	float timeElapsed = 0;
	float spawnCycle = 5.0f;
	int spawnPlace = 0;
	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > (spawnCycle))
		{
			GameObject temp2;
			temp2 = (GameObject)Instantiate(Trashcan1);
			Vector3 pos = temp2.transform.position;
			spawnPlace = Random.Range(1, 3);
			if (spawnPlace == 1)
			{
				temp2.transform.position = new Vector3( -31, 0.3f, (pos.z + 200));
			}
			else
			{
				temp2.transform.position = new Vector3( -13, 0.3f, (pos.z + 200));
			}
			timeElapsed -= spawnCycle;
		}
	}
}
