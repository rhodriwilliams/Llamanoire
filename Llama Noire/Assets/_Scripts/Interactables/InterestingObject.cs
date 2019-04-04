using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class InterestingObject : Interactable {

	public float rotateSpeed;
	public Transform inspectTransform;

	public CinemachineVirtualCamera virtualCamera;

	private Vector3 initialLocation;
	private Vector3 startLocation;
	private Vector3 targetLocation;

	private Quaternion currentRotation;
	private Quaternion initialRotation;
	private float x = 0f;
	public string objectiveName;
	[TextArea]
	public string flavourText;
	public bool pickup;
	protected bool hasInspected;
	protected float colliderSize;
	void Start(){
		colliderSize = GetComponent<SphereCollider>().radius;
		initialRotation = transform.rotation;

		initialLocation = transform.position;
		targetLocation = initialLocation;
	}

	void Update(){
		if(targetLocation != transform.position){
			transform.position = Vector3.Lerp(startLocation, targetLocation, x);
			transform.rotation = Quaternion.Lerp(currentRotation, initialRotation, x);
			x += Time.deltaTime;
		}
		if(beingInteracted)
			transform.Rotate(0f, - Input.GetAxis("Mouse X") * rotateSpeed,  Input.GetAxis("Mouse Y") * rotateSpeed, Space.World);
	}

	/*
	void OnMouseDrag(){
		if(beingInteracted)
			transform.Rotate(0f, - Input.GetAxis("Mouse X") * rotateSpeed,  Input.GetAxis("Mouse Y") * rotateSpeed, Space.World);
	}
	*/


	public override void Interact(){
		if(!beingInteracted){
			if(isHovering){
				GetComponent<SphereCollider>().radius = colliderSize * 10f;
				if(flavourText != ""){
					GameObject.Find("FlavourText").GetComponent<Text>().text = flavourText;
				}
				if(!hasInspected){
					hasInspected = true;
					GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>().IncrementInt("Clues");
				}
				beingInteracted = true;
				toolTip.ClearTip();
				player.gameObject.GetComponent<RhunCharacter>().ToggleCursor();
				virtualCamera.Priority = 100;
				if(objectiveName != ""){
						GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>().SetBool(objectiveName, true);
				}
				x = 0f;
				currentRotation = transform.rotation;
				startLocation = transform.position;
				targetLocation = inspectTransform.position;
			} 
		}else {
			GetComponent<SphereCollider>().radius = colliderSize;
			if(flavourText != ""){
				GameObject.Find("FlavourText").GetComponent<Text>().text = "";
			}
			beingInteracted = false;
			player.gameObject.GetComponent<RhunCharacter>().ToggleCursor();
			virtualCamera.Priority = 0;
			if(pickup){
				Destroy(gameObject);
			} else {
				x = 0f;
					currentRotation = transform.rotation;
				startLocation = transform.position;
				targetLocation = initialLocation;
			}
		}
	}
}
