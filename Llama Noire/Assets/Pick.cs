using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour {

	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}
	void Update () {
		rb.AddForce(new Vector2(0f, Input.GetAxis("Vertical") * 5000f));
	}
}
