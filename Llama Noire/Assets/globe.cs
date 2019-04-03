using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globe : Interactable {

	public override void Interact(){
		GetComponent<Rigidbody>().AddTorque(0f, 1000f, 0f);
	}
}
