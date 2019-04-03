﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(AudioSource))]
public class Door : Interactable {
	public bool isLocked;
	public bool isOpen;
	protected Animation anim;
	protected bool AIUsing = false;
	protected AudioSource source;
	public bool isPatsyDoor = false;
	void Start(){
		anim = transform.parent.GetComponent<Animation>();
		source = GetComponent<AudioSource>();
	}
	public override void Interact(){
		if(!anim.isPlaying){
			if(!isOpen){
				if(!isLocked){
					
					Open();
				} else {
					GetComponentInChildren<Lock>().Interact();
				}
			} else {
				if(!AIUsing){
					isOpen = false;
					anim.clip = anim.GetClip("Close");
					anim.Play();
				}
			}
		}
	}
	public void OnTriggerEnter(Collider other){
		if(!AIUsing){
			if(other.tag == "AI"){
				StartCoroutine("OpenClose");
			}
		}
		if(other.gameObject == player){
			if(!beingInteracted){
				ShowTip();
			}
		}
	}
	public virtual void Open(){
		if(isPatsyDoor){
			ObjectiveManager man = GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>();
			man.SetHidden("GetDrink", true);
			man.SetHidden("SpeakToPatsy", true);
			man.SetHidden("FindPacone", false);
		}
		source.Play();
		isOpen = true;
		anim.clip = anim.GetClip("Open");
		anim.Play();
		player.GetComponentInChildren<Animator>().SetTrigger("OpenDoor");
	}
	public IEnumerator OpenClose(){
		AIUsing = true;
		if(!isOpen){
			isOpen = true;
			anim.clip = anim.GetClip("Open");
			anim.Play();
		}
		yield return new WaitUntil(() => !anim.isPlaying);
		yield return new WaitForSeconds(4f);
		AIUsing = false;
		isOpen = false;
		anim.clip = anim.GetClip("Close");
		anim.Play();
	}
}
