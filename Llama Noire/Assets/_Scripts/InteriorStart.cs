using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorStart : MonoBehaviour {

	// delete asap
	void Start () {
		GetComponent<RhunCharacter>().busy = false;
		GetComponentInChildren<Animator>().SetBool("InMenu", false);
	}

}
