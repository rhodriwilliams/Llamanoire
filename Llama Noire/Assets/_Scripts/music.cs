using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

	protected bool isSinging {get; set;}
	public bool IsSinging {
		get{
			return isSinging;
		}
		set{
			isSinging = value;
		}
	}
	public AudioClip newClip;
	protected bool inside;

	protected AudioSource source;
	// Use this for initialization
	void Start () {
		isSinging = false;
		SceneManager.sceneLoaded += OnSceneLoaded;
		source = GetComponent<AudioSource>();
		source.time = 120f;
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		Debug.Log("Scene loaded: " + scene.name);
		if(scene.name == "InteriorSpeakeasyWhitebox"){
			inside = true;
			GetComponent<AudioLowPassFilter>().enabled = false;
			source.spatialBlend = 0f;
			source.loop = false;
			source.volume = 0.4f;
			
			float timeLeft = source.clip.length - source.time;
			Invoke("NewSong", timeLeft);
		}
	}
	void Update(){
		/*
		if(!source.isPlaying){
			if(inside){
				source.clip = newClip;
				source.volume = 0.25f;
				source.Play();

			}
		}
		*/
	}

	void NewSong(){
		isSinging = !isSinging;
		GameObject[] clappers = GameObject.FindGameObjectsWithTag("Clapping");
		GameObject[] dancers = GameObject.FindGameObjectsWithTag("Dancing");
		foreach(GameObject g in clappers){
			g.GetComponent<Animator>().SetTrigger("SongFinished");
		}
		foreach(GameObject g in dancers){
			g.GetComponent<Animator>().SetBool("SongPlaying", false);
		}
	}
	public void StartSinging(){
		Debug.Log("Got it");
		source.clip = newClip;
		source.volume = 0.25f;
		source.Play();
	}
}
