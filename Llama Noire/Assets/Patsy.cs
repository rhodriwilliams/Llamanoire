using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patsy : MonoBehaviour {

	public Transform singWaypoint;
	public Transform[] otherWaypoints;
	private NavMeshAgent agent;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();

		anim.SetBool("IsDancing", true);
		//agent.SetDestination(singWaypoint.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
