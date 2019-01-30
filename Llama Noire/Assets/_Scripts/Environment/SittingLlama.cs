using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingLlama : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		StartCoroutine("Wait");
	}
	
	IEnumerator Wait(){
		anim.SetInteger("AnimationRandom", Random.Range(0, 3));
		yield return new WaitForSeconds(5f);
		StartCoroutine("Wait");
	}
}
