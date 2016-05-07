using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject obstacle;
	public GameObject powerup;
	public GameObject busstops;
	public GameObject skate;


	float rounds = 0;
	float rands = 0;
	float timeElapsed = 0;
	float spawnCycle = 0.25f;
	bool spawnPowerup = true;
	float getRespawnCycle = 0;
	int item = 1;

	
	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp;
			GameObject temp2;
			GameObject temp3;
			GameObject temp4;
			//GameObject temp5;
			//GameObject temp6;

			if(spawnPowerup)
			{
				//spawnCycle = 0.5f;
				temp = (GameObject)Instantiate(powerup);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
				rounds = rounds + 1;
			}
			else
			{
				//spawnCycle = 0.125f;
				temp = (GameObject)Instantiate(powerup);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
				rounds = rounds + 1;
			}
			getRespawnCycle = GameControlScript.respawnCycle;
			rands = rounds;
			if ((rands%getRespawnCycle) == 0)
			{
				temp3 = (GameObject)Instantiate(obstacle);
				Vector3 pos = temp3.transform.position;
				temp3.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
			}
			if (rands == 25)
			{
				temp4 = (GameObject)Instantiate(skate);
				Vector3 pos = temp4.transform.position;
				temp4.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z + Random.Range(-3, 4));
			}
			if (rounds == 40)
			{
				temp2 = (GameObject)Instantiate(busstops);
				Vector3 pos = temp2.transform.position;
				temp2.transform.position = new Vector3(5, pos.y, pos.z);
				rounds = 0;
			}
			/*if((rands%getRespawnCycle == 0f) || (rands%getRespawnCycle == 1f) || (rands%getRespawnCycle == 2f) || (rands%getRespawnCycle == 4f) || (rands%getRespawnCycle == 5f) || (rands%getRespawnCycle == 6f))
			{
				//spawnCycle = 0.5f;
				temp = (GameObject)Instantiate(powerup);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
				rounds = rounds + 1;
			}*/
			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
		}
	}
}