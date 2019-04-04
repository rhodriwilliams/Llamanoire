using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patsy : MonoBehaviour {

	protected enum PatsyMode {None, BackStage, ToStage, OnStage, OffStage, GoingBackup, GoingUpstairs};
	[SerializeField]
	protected PatsyMode currentMode = PatsyMode.None;
	protected Music music;
	public Transform singWaypoint;
	public Transform[] otherWaypoints;
	public Transform backupWaypoint;
	public Transform upstairsWaypoint;
	private NavMeshAgent agent;
	private Animator anim;
	protected bool goingToStage = false;

	protected TalkativeNPC talkScript;
	// Use this for initialization
	void Start () {
		talkScript = GetComponent<TalkativeNPC>();
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
		//Debug.Log((transform.position - agent.destination).magnitude);
		switch(currentMode){
		case PatsyMode.BackStage:
			//if song is over, go to stage
			if(music.IsSinging){
				if(!GetComponent<TalkativeNPC>().beingInteracted){
					//anim.SetFloat("Input Y", 1f);
					anim.SetBool("IsWalking", true);
					agent.SetDestination(singWaypoint.position);
					currentMode = PatsyMode.ToStage;
					GetComponent<SphereCollider>().enabled = false;
				}
			}
			break;
		case PatsyMode.ToStage:
			//if at stage, switch to onstage
			if((transform.position - agent.destination).magnitude < 0.1f){
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
			if((transform.position - agent.destination).magnitude < 0.1f){
				GetComponent<SphereCollider>().enabled = true;
				anim.SetBool("IsWalking", false);
				currentMode = PatsyMode.BackStage;
			}
			break;
		case PatsyMode.GoingBackup:
			if((transform.position - agent.destination).magnitude < 0.1f){
				StartCoroutine("WaitForBackup");
				anim.SetBool("IsWalking", false);
				currentMode = PatsyMode.None;
			}
			break;
		case PatsyMode.GoingUpstairs:
			if((transform.position - agent.destination).magnitude < 1f){
				currentMode = PatsyMode.None;
				anim.SetBool("IsWalking", false);
				GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>().SetBool("PatsyUpstairs", true);
			}
			break;
		default:
			break;
		}
	}

	public void GetBackup(){
		agent.SetDestination(backupWaypoint.position);
		anim.SetBool("IsWalking", true);
		currentMode = PatsyMode.GoingBackup;
	}

	public IEnumerator WaitForBackup(){
		//Debug.Log("Do the art stuff");
		GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
		yield return new WaitForSeconds(5f);
		GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
		agent.SetDestination(upstairsWaypoint.position);
		anim.SetBool("IsWalking", true);
		currentMode = PatsyMode.GoingUpstairs;
	}
}
