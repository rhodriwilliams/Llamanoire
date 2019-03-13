using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideControls : MonoBehaviour {
	protected Transform cam;
	protected RhunCharacter character;

	protected bool camInFront = false;
	void Start(){
		cam = Camera.main.transform;
		character = GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>();
	}
	// Update is called once per frame
	void Update () {
		if(!character.busy){
			if(camInFront){
				if(cam.position.z > transform.position.z){
					Destroy(gameObject);
				}
			} else if (cam.position.z < transform.position.z){
				camInFront = true;
			}
		}
	}
}
