using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : Interactable {

	public override void Interact(){
		if(!beingInteracted){
			beingInteracted = true;
			toolTip.ClearTip();
			player.GetComponent<RhunCharacter>().StopMoving();
			player.GetComponentInChildren<Animator>().SetBool("IsDancing", true);
		} else {
			beingInteracted = false;
			player.GetComponent<RhunCharacter>().StopMoving();
			player.GetComponentInChildren<Animator>().SetBool("IsDancing", false);
		}
	}
}
