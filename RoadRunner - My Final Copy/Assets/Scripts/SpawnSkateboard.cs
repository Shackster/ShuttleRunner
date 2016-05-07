using UnityEngine;
using System.Collections;

public class SpawnSkateboard : MonoBehaviour {
	public GameObject Skateboard;
	
	float timeElapsed = 0;
	float spawnCycle = 0.125f;
	bool spawnPowerup = true;
	
	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp;
			if(spawnPowerup)
			{
				//spawnCycle = 0.5f;
				temp = (GameObject)Instantiate(Skateboard);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, (pos.z + 40));
				//transform.Translate(Vector3.up * Time.deltaTime, Space.World);
			}
			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
		}
	}
}