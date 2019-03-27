using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;
public class PatsyObjectives : ObjectiveListener {
	protected Patsy patsyScript;
	//protected NavMeshAgent agent;
	// Use this for initialization
	void Awake () {
		patsyScript = GetComponent<Patsy>();
		//agent = GetComponent<NavMeshAgent>();
	}
	
	protected override void CompleteObjective(){
		//switch patsy script to the other one?
		Debug.Log("Completed");
		patsyScript.GetBackup();
	}
}
