using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	void Awake(){
		Debug.Log("I exist");
	}
	void OnDestroy(){
		Debug.Log("Yeet");
	}
}
