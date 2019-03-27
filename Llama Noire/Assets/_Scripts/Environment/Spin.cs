using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	    void Update ()
    {
        transform.Rotate (0,200*Time.deltaTime,0); //rotates 50 degrees per second around z axis
    }
}
