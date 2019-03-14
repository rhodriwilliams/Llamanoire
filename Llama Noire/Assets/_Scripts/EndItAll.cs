using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndItAll : Interactable {

	
	void Start () {
		GetComponent<Rigidbody>().AddForce(0f,1000f,-10000f);
	}
	
	
}
