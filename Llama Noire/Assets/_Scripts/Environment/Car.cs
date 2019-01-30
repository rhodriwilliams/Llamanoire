using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public float distance;
	public float maxSpeed;
	

	public float acceleration;

	[HideInInspector]
	public float targetSpeed;
	[HideInInspector]
	public float curSpeed;
	private float distanceTraveled;

	void Start(){
		targetSpeed = maxSpeed;
		curSpeed = targetSpeed;
	}
	void Update () {
		if(curSpeed < targetSpeed){
			curSpeed = Mathf.Clamp(curSpeed + acceleration * Time.deltaTime, 0f, targetSpeed);
		} else if(curSpeed > targetSpeed){
			curSpeed = Mathf.Clamp(curSpeed - acceleration * Time.deltaTime, targetSpeed, maxSpeed);
		}
		if(distanceTraveled < distance){
			transform.position += transform.forward * (curSpeed * Time.deltaTime);
			distanceTraveled += curSpeed * Time.deltaTime;
		} else {
			Destroy(gameObject);
		}
		/*
		if(!isStopping){
			if(curSpeed < speed)
				curSpeed = Mathf.Clamp(curSpeed + acceleration * Time.deltaTime, 0f, speed);
		} else {
			if(curSpeed > 0)
				curSpeed = Mathf.Clamp(curSpeed - acceleration * Time.deltaTime, 0f, speed);
		}
		
		*/
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
			targetSpeed = 0f;
		else if (other.tag == "Car" && !other.isTrigger){
			targetSpeed = other.gameObject.GetComponent<Car>().curSpeed;
		}
	}

	void OnTriggerExit(Collider other){
		targetSpeed = maxSpeed;
	}
}
