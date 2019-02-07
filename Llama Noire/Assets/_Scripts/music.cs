using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour {

	public AudioClip newClip;
	protected bool inside;

	protected AudioSource source;
	// Use this for initialization
	void Start () {
		SceneManager.sceneLoaded += OnSceneLoaded;
		source = GetComponent<AudioSource>();
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		Debug.Log("Scene loaded: " + scene.name);
		if(scene.name == "InteriorSpeakeasyWhitebox"){
			inside = true;
			GetComponent<AudioLowPassFilter>().enabled = false;
			source.spatialBlend = 0f;
			source.loop = false;
			source.volume = 0.4f;
		}
	}
	void Update(){
		if(!source.isPlaying){
			if(inside){
				source.clip = newClip;
				source.volume = 0.25f;
				source.Play();

			}
		}
	}
}
