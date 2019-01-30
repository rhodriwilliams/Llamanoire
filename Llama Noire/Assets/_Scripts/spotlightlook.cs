using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotlightlook : MonoBehaviour {

	public Transform lookAt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(lookAt);
	}
}
