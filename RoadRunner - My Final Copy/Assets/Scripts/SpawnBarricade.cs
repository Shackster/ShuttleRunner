using UnityEngine;
using System.Collections;

public class SpawnBarricade : MonoBehaviour {
	public GameObject Barricade;
	float timeElapsed = 0;
	float spawnCycle = 1.0f;
	int spawnPlace = 0;
	void Update () 
	{
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp1;
			temp1 = (GameObject)Instantiate(Barricade);
			Vector3 pos = temp1.transform.position;
			spawnPlace = Random.Range(1, 3);
			if (spawnPlace == 1)
			{
				temp1.transform.position = new Vector3( -2.5f, pos.y, (pos.z + 200));
			}
			else
			{
				temp1.transform.position = new Vector3( 2.5f, pos.y, (pos.z + 200));
			}
			timeElapsed -= spawnCycle;
		}
	}
}
