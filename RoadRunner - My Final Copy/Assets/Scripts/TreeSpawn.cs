using UnityEngine;
using System.Collections;

public class TreeSpawn : MonoBehaviour {
	public GameObject Tree;
	float timeElapsed = 0;
	float spawnCycle = 1.5f;
	int spawnPlace = 0;
	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp1;
			temp1 = (GameObject)Instantiate(Tree);
			Vector3 pos = temp1.transform.position;
			spawnPlace = Random.Range(1, 3);
			if (spawnPlace == 1)
			{
				temp1.transform.position = new Vector3( -6, pos.y, (pos.z + 200));
			}
			else
			{
				temp1.transform.position = new Vector3( 6, pos.y, (pos.z + 200));
			}
			timeElapsed -= spawnCycle;
		}
	}
}
