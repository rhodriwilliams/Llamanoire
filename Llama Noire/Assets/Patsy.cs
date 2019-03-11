using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patsy : MonoBehaviour {

	protected enum PatsyMode {None, BackStage, ToStage, OnStage, OffStage};
	[SerializeField]
	protected PatsyMode currentMode = PatsyMode.None;
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
			currentMode = PatsyMode.OnStage;
			agent.Warp(singWaypoint.position);
			anim.SetBool("IsDancing", true);
		} else {
			currentMode = PatsyMode.BackStage;
			agent.Warp(otherWaypoints[0].position);
			anim.SetBool("IsDancing", false);
		}
	}
	
	void Update () {
		switch(currentMode){
		case PatsyMode.BackStage:
			//if song is over, go to stage
			if(music.IsSinging){
				anim.SetBool("IsWalking", true);
				agent.SetDestination(singWaypoint.position);
				currentMode = PatsyMode.ToStage;
			}
			break;
		case PatsyMode.ToStage:
			//if at stage, switch to onstage
			if(agent.remainingDistance < 0.1){
				anim.SetBool("IsDancing", true);
				music.StartSinging();
				currentMode = PatsyMode.OnStage;
			}
			break;
		case PatsyMode.OnStage:
			//if song is over, get off stage
			if(!music.IsSinging){
				agent.SetDestination(otherWaypoints[0].position);
				anim.SetBool("IsDancing", false);
				currentMode = PatsyMode.OffStage;
			}
			break;
		case PatsyMode.OffStage:
			//if backstage, switch to backstage
			if(agent.remainingDistance < 0.1){
				anim.SetBool("IsWalking", false);
				currentMode = PatsyMode.BackStage;
			}
			break;
		default:
			break;
		}
		/*
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
		*/
	}
}
