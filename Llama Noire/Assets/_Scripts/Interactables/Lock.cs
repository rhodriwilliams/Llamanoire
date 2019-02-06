using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Interactable {
	protected Door door;
	protected HasKey keyScript;
	[SerializeField]
	protected GameObject lockpickingMinigame;
	[SerializeField]
	protected int difficulty;

	void Start(){
		keyScript = GetComponent<HasKey>();
		if(transform.parent.GetComponent<Door>()){
			door = transform.parent.GetComponent<Door>();
		} else {
			Debug.LogWarning("Lock Has no Parent!");
		}
	}
	public override void Interact(){
		if(!door.isOpen){ //can't lock an open door
			if(keyScript.HaveKey){
				//allow players with the key to lock/unlock the door freely
				LockUnlock();
			} else {
				if(door.isLocked){ //no need to lockpick a door shut
					//instantiate the lockpicking minigame and pause the game
					GameObject newMinigame = Instantiate(lockpickingMinigame, Vector3.zero, Quaternion.identity);
					newMinigame.GetComponent<Lockpicking>().LockScript = this;
					newMinigame.GetComponent<Lockpicking>().Setup(difficulty);
					beingInteracted = true;
					player.gameObject.GetComponent<RhunCharacter>().ToggleCursor();
				}	
			}
		}
	}
	public void LockpickingComplete(bool successful){
		//called by the minigame object when lockpicking is over
		beingInteracted = false;
		player.gameObject.GetComponent<RhunCharacter>().ToggleCursor();
		if(successful){
			LockUnlock();
		}
	}
	protected void LockUnlock(){
		door.isLocked = !door.isLocked;
	}
}
