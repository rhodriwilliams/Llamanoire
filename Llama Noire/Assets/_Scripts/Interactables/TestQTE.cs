using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQTE : Interactable {
	public GameObject qteMinigame;
	public ScriptableQTE qteScript;
	public override void Interact(){
		if(!beingInteracted){
			GameObject newMinigame = Instantiate(qteMinigame, Vector3.zero, Quaternion.identity);
			newMinigame.GetComponent<QuicktimeEvent>().Setup(qteScript, this);
			beingInteracted = true;
			player.gameObject.GetComponent<RhunCharacter>().ToggleCursor();
		}
	}
	public void EndQTE(){
		beingInteracted = false;
		player.gameObject.GetComponent<RhunCharacter>().ToggleCursor();
	}
}
