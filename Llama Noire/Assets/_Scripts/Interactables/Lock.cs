using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Interactable {
	protected Door daddy;

	void Start(){
		if(transform.parent.GetComponent<Door>()){
			daddy = transform.parent.GetComponent<Door>();
		} else {
			Debug.LogWarning("Lock Has no Parent!");
		}
	}
	public override void Interact(){
		daddy.isLocked = !daddy.isLocked;
	}
}
