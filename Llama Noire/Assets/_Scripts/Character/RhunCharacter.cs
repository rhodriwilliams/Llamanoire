using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class RhunCharacter : MonoBehaviour {

	public bool busy = true;

	private Transform mainCamera;
	public float speed;
	private CharacterController controller;

	private Animator animator;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		CinemachineCore.GetInputAxis = GetAxisCustom;
		animator = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!busy){
			Vector3 forward = mainCamera.forward * Input.GetAxis("Vertical");
			Vector3 right = mainCamera.right * Input.GetAxis("Horizontal");
			Vector3 movement = (forward + right);
			movement = movement.normalized;
			controller.SimpleMove(movement * speed);

			if(movement.magnitude > 0){
				if(!animator.GetBool("IsWalking"))
					animator.SetBool("IsWalking", true);

				float camYAngle = mainCamera.rotation.eulerAngles.y;
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camYAngle, 0f), 0.1f);

			} else if (animator.GetBool("IsWalking"))
				animator.SetBool("IsWalking", false);
			//transform.rotation = Quaternion.LookRotation(forward);
		} 
	}
	public void ToggleCursor(){
		busy = !busy;
		Cursor.visible = !Cursor.visible;
		if(Cursor.lockState == CursorLockMode.Locked){
			Cursor.lockState = CursorLockMode.None;
			if(animator.GetBool("IsWalking"))
				animator.SetBool("IsWalking", false);
		}
		else
			Cursor.lockState = CursorLockMode.Locked;
	}

	public float GetAxisCustom(string axisName){
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>().busy)
			return 0f;
		return Input.GetAxis(axisName);
	}
}
