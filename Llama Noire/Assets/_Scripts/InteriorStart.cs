using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorStart : MonoBehaviour {

	void Start () {
		GetComponent<RhunCharacter>().busy = false;
		GetComponentInChildren<Animator>().SetBool("InMenu", false);
		GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>().SetBool("GetInSpeakeasy", true);
	}
}
