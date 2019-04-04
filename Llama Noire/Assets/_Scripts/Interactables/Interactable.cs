using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour {
	public bool requireHover = true;
	protected ToolTip toolTip;
	public string objectName;
	protected bool isHovering = false;
	[HideInInspector]
	public bool beingInteracted = false;
	protected GameObject player;
	protected Transform mainCamera;
	protected int playerLayer;
	void Awake(){
		playerLayer = 1 << 10;
		player = GameObject.FindGameObjectWithTag("Player");
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<ToolTip>();
	}
	void OnTriggerEnter(Collider other){
	if(!requireHover){
		if(other.gameObject == player){
			if(!beingInteracted)
				ShowTip();
		}
	}
	}
	void OnTriggerStay(Collider other){
		if(other.gameObject == player){
			
			if(requireHover){
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
			} else {
			if(Input.GetButtonDown("Interact"))
				Interact();
			}
		}
	}

	public virtual void Interact(){}

	protected bool CameraIsPointingAt(){
		RaycastHit hit;
		if(Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, 100f, ~playerLayer)){
			return (hit.collider.gameObject == gameObject);
		} else {
			return false;
		}
	}

	protected void ShowTip(){
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
	void OnDestroy(){
		if(isHovering){
			isHovering = false;
			toolTip.ClearTip();
		}
	}
}
