using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Push : Interactable{
	public CinemachineVirtualCamera cam;
	public GameObject ragdoll;
	public override void Interact(){
		cam.Priority = 100;
		Instantiate(ragdoll, transform.position, transform.rotation);
		Destroy(gameObject);
	}
	
}
