using UnityEngine;
using System.Collections;

public class SpawnGate : MonoBehaviour {
	public GameObject Ramp;
	public GameObject Gate;
	float timeElapsed = 0;
	float spawnCycle = 15.0f;
	int spawnPlace = 0;
	void Update () 
	{
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp1;
			temp1 = (GameObject)Instantiate(Gate);
			Vector3 pos = temp1.transform.position;
			temp1.transform.position = new Vector3(0, pos.y, (pos.z + 400));
			GameObject temp2;
			temp2 = (GameObject)Instantiate(Ramp);
			Vector3 pos2 = temp1.transform.position;
			temp2.transform.position = new Vector3( Random.Range(-3, 4), pos2.y, (pos2.z - 4));
			timeElapsed -= spawnCycle;
		}
	}
	/*
	//public GameObject Gate;
	public GameObject Ramp;
	float timeElapsed = 0;
	float spawnCycle = 1.0f;
	void Update () 
	{

		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp1;
			//temp1 = (GameObject)Instantiate(Gate);
			//Vector3 pos = temp1.transform.position;
			//temp1.transform.position = new Vector3( 0, pos.y, (pos.z + 200));
			temp1 = (GameObject)Instantiate(Ramp);
			Vector3 pos = temp1.transform.position;
			temp1.transform.position = new Vector3( 0, pos.y, (pos.z + 200));
		}
		//timeElapsed -= spawnCycle;
	}
	*/
}