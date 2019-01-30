using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

	public GameObject[] prefabs;

	void Start(){
		Spawn();
	}

	void Spawn(){
		GameObject toSpawn = prefabs[Random.Range(0, prefabs.Length)];
		Instantiate(toSpawn, transform.position, transform.rotation);
		Invoke("Spawn", Random.Range(5f, 15f));
	}
}
