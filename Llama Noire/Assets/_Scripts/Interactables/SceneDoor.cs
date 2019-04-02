using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDoor : Door {
	[SerializeField] protected string nextScene;
	[SerializeField] protected string entrance; //which entrance is this door? name of the transform in the next scene where the player should spawn
	protected SceneChanger sceneChanger;
	void Start(){
		source = GetComponent<AudioSource>();
		anim = transform.parent.GetComponent<Animation>();
		sceneChanger = GameObject.FindGameObjectWithTag("Manager").GetComponent<SceneChanger>();
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
					if(anim){
						anim.clip = anim.GetClip("Close");
						anim.Play();
					}
				}
			}
		}
	}
	public override void Open(){
		source.Play();
		isOpen = true;
		if(anim){
			anim.clip = anim.GetClip("Open");
			anim.Play();
		}
		player.GetComponentInChildren<Animator>().SetTrigger("OpenDoor");
		sceneChanger.LoadScene(nextScene, entrance);
	}
}
