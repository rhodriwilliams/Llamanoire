using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
	public ToolTip toolTip;
	public string objectName;
	protected bool isHovering = false;
	[HideInInspector]
	public bool beingInteracted = false;
	protected GameObject player;
	protected Transform mainCamera;

	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player");
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<ToolTip>();
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject == player){
			if(Input.GetButtonDown("Interact") && isHovering)
				Interact();
			if(CameraIsPointingAt()){
				isHovering = true;
				if(!beingInteracted)
					ShowTip();
			} else if(isHovering){
				toolTip.ClearTip();
				isHovering = false;
			}
		}
	}

	public virtual void Interact(){}

	protected bool CameraIsPointingAt(){
		RaycastHit hit;
		if(Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, 100f)){
			return (hit.collider.gameObject == gameObject);
		} else {
			return false;
		}
	}

	void ShowTip(){
		string tip = "";
		tip += objectName;
		tip += " [Press E to interact]";
		toolTip.NewTip(tip);
	}


	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player){
			toolTip.ClearTip();
		}
	}
}
