using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patsy : MonoBehaviour {

	protected Music music;
	public Transform singWaypoint;
	public Transform[] otherWaypoints;
	private NavMeshAgent agent;
	private Animator anim;
	protected bool goingToStage = false;
	// Use this for initialization
	void Start () {
		music = GameObject.Find("music").GetComponent<Music>();
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();

		
		anim.SetBool("InMenu", false);
		//agent.SetDestination(otherWaypoints[0].position);
		if(music.IsSinging){
			agent.Warp(singWaypoint.position);
			anim.SetBool("IsDancing", true);
		} else {
			agent.Warp(otherWaypoints[0].position);
			anim.SetBool("IsDancing", false);
		}
	}
	
	void Update () {
		if(agent.remainingDistance < 0.1f){
			if(goingToStage){
				Debug.Log("At stage");
				anim.SetBool("IsDancing", true);
				music.StartSinging();
				goingToStage = false;
			} else {
				if(anim.GetBool("IsWalking")){
					anim.SetBool("IsWalking", false);
				}
			}
		} else if (!anim.GetBool("IsWalking")){
			Debug.Log("Walking");
			anim.SetBool("IsWalking", true);
		}
		if(music.IsSinging){
			agent.SetDestination(singWaypoint.position);
			goingToStage = true;
		}
	}
}
