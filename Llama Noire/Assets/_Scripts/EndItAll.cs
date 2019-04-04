using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndItAll : MonoBehaviour {

	
	void Start () {
		GetComponent<Rigidbody>().AddRelativeForce(0f,4750f,-9750f);
	}
	
	
}
