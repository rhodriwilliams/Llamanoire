using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

	private Light flickerLight;

	public float flickerChance;

	// Use this for initialization
	void Start () {
		flickerLight = gameObject.GetComponent<Light>();
		StartCoroutine("StayOn");
	}

	IEnumerator StayOn(){
		yield return new WaitForSeconds(Random.Range(1.0f,5.0f));
		StartCoroutine("Flicker");
	}

	IEnumerator Flicker(){
		
		flickerLight.enabled = false;
		yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
		flickerLight.enabled = true;
		if(Random.Range(0.0f, 1.0f) <= flickerChance){
			yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
			StartCoroutine("Flicker");
		}else{
			StartCoroutine("StayOn");
		}
	}
}
