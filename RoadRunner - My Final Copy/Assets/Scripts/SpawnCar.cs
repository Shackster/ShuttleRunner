using UnityEngine;
using System.Collections;

public class SpawnCar : MonoBehaviour {
	public GameObject Car;
	float timeElapsed = 0;
	float spawnCycle = 10.0f;
	int spawnPlace = 0;
	void Update () 
	{
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp1;
			temp1 = (GameObject)Instantiate(Car);
			Vector3 pos = temp1.transform.position;
			spawnPlace = Random.Range(1, 3);
			if (spawnPlace == 1)
			{
				temp1.transform.position = new Vector3( -2, pos.y, (pos.z + 200));
			}
			else
			{
				temp1.transform.position = new Vector3( 2, pos.y, (pos.z + 200));
			}
			timeElapsed -= spawnCycle;
		}
	}
}
