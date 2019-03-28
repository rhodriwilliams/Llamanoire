using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public float lifeTime;
	public float maxSpeed;

	public float acceleration;

	[HideInInspector]
	public float targetSpeed;
	[HideInInspector]
	public float curSpeed;

	protected Rigidbody rb;
	[SerializeField]
	protected bool somethingInFront;
	void Start(){
		rb = GetComponent<Rigidbody>();
		targetSpeed = maxSpeed;
		curSpeed = targetSpeed;
		rb.velocity = transform.forward * maxSpeed;
		Destroy(gameObject, lifeTime);
	}
	void Update () {
		rb.AddTorque(0f, 0f, 0f);

		if(somethingInFront){
			if(rb.velocity.magnitude > 0.2){
				Debug.Log(rb.velocity.magnitude);
				rb.AddForce(transform.forward * - acceleration);
			} else {
				rb.velocity = Vector3.zero;
			}
		}
		else if (rb.velocity.magnitude < maxSpeed){
			rb.AddForce(transform.forward * acceleration);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" || other.tag == "Car")
			somethingInFront = true;
	}


	void OnTriggerExit(Collider other){
		if(other.tag == "Player")
			somethingInFront = false;
	}
}
