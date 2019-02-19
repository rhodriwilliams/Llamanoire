using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour {

	private GameObject player;
	public float defaultSensitivity;
	[HideInInspector]
	public float sensitivity;
	public float maxRot;
	public float minRot;
	public bool inverted;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(!player.GetComponent<RhunCharacter>().busy){
			transform.position = player.transform.position;

			Vector3 curRot = transform.rotation.eulerAngles;
			float newXRot = 0f;
			if(inverted)
				newXRot = RotationClamp(curRot.x + Input.GetAxis("Mouse Y") * sensitivity, minRot, maxRot);
			else
				newXRot = RotationClamp(curRot.x - Input.GetAxis("Mouse Y") * sensitivity, minRot, maxRot);
			Quaternion newRot = Quaternion.Euler(
				newXRot,
				curRot.y + Input.GetAxis("Mouse X") * sensitivity,
				curRot.z
			);
			//Quaternion slowRot = Quaternion.Lerp(Quaternion.Euler(curRot), newRot, 0.1f);
			transform.rotation = newRot;
		}
	}

	float RotationClamp(float value, float min, float max){
		if(min > 0f){
			return Mathf.Clamp(value, min, max);
		} else {
			min = 360f + min;
			if(value >= min)
				return value;
			if(value <= max)
				return value;
			if(value < min && value >= 180)
				return min;
			if(value > max && value < 180)
				return max;
			else
				return value;
		}
	}
}
