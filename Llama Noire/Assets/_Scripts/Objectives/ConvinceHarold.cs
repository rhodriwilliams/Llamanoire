using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvinceHarold : ObjectiveListener {
	public TalkativeNPC dialogue;
	public bool isFrank = false;
	protected override void CompleteObjective(){
		GetComponent<BoxCollider>().isTrigger = true;
		Destroy(gameObject);
	}

	public void OnTriggerEnter(Collider other){
		Debug.Log("Collision!");
		if(other.tag == "Player"){
			dialogue.Interact();
			if(isFrank){
				manager.SetBool("FindPacone", true);
				manager.SetBool("GetUpstairs", true);
			}
		}
	}
}
