using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pedestrians : MonoBehaviour {

	public GameObject pedestrianPrefab;
	public Transform spawnPoint;

	public float spawnRate;

	public int numOfPedestrians;
	public bool spawnOnStart;

	void Start(){
		if(spawnOnStart){
			StartCoroutine("Wait");
		}
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds(Random.Range(25f, 35f));
		GameObject instance = Instantiate(pedestrianPrefab, spawnPoint.position, spawnPoint.rotation);
		instance.GetComponent<NavMeshAgent>().destination = transform.position;
		StartCoroutine("Spawn");
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds(Random.Range(10f, 35f));
		for(int i = 0; i < numOfPedestrians; i++){
			StartCoroutine("Spawn");
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Pedestrian"){
			Destroy(other.gameObject);
		}
	}
}
