using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {
	public bool isLocked;
	public bool isOpen;
	protected Animation anim;

	void Start(){
		anim = transform.parent.GetComponent<Animation>();
	}
	public override void Interact(){
		if(!anim.isPlaying){
			if(!isOpen){
				if(!isLocked){
					isOpen = true;
					anim.clip = anim.GetClip("Open");
					anim.Play();
				}
			} else {
				isOpen = false;
				anim.clip = anim.GetClip("Close");
				anim.Play();
			}
		}
	}
}
