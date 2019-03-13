using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

	void Update () {
		transform.Rotate(0f, 0f, Input.GetAxis("Horizontal"));
	}
}
