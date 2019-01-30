using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skiplevel : MonoBehaviour {
	public bool cheatsOn;
	void Update () {
		if(Input.GetButtonDown("SkipLevel") && cheatsOn){
			SceneManager.LoadScene("InteriorSpeakeasyWhitebox");
		}
	}
}
