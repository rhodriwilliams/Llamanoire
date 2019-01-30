using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkativeNPC : Interactable{

	private Dialogue dialogue;

	void Start(){
		dialogue = gameObject.GetComponent<Dialogue>();
	}
	public override void Interact(){
		if(!beingInteracted){
			dialogue.StartDialogue();
			player.GetComponent<RhunCharacter>().ToggleCursor();
			toolTip.ClearTip();
			beingInteracted = true;
		}
	}
}
