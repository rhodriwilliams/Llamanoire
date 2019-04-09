using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndItAllToo : MonoBehaviour 
{
	void Start () 
	{
		GetComponent<Rigidbody>().AddRelativeForce(0f,75f,-750f);
	}
}