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
	public AudioClip oldClip;
	public AudioClip newClip;
	protected bool inside;

	protected GameObject[] clappers;
	protected GameObject[] dancers;

	protected AudioSource source;
	// Use this for initialization
	void Start () {
		isSinging = false;
		SceneManager.sceneLoaded += OnSceneLoaded;
		source = GetComponent<AudioSource>();
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		if(scene.name == "Apartment"){
			source.Pause();
		} else{
			source.Play();
		}
		clappers = GameObject.FindGameObjectsWithTag("Clapping");
		dancers = GameObject.FindGameObjectsWithTag("Dancing");
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
		if(!isSinging){
			source.clip = oldClip;
			source.volume = 0.25f;
			source.time = 0.0f;
			source.Play();
		} else {
			foreach(GameObject g in dancers){
				g.GetComponent<Animator>().SetBool("SongPlaying", false);
			}
		}
		foreach(GameObject g in clappers){
			g.GetComponent<Animator>().SetTrigger("SongFinished");
		}
		
	}
	public void StartSinging(){
		foreach(GameObject g in clappers){
			g.GetComponent<Animator>().SetTrigger("SongFinished");
		}
		foreach(GameObject g in dancers){
			g.GetComponent<Animator>().SetBool("SongPlaying", true);
		}
		//Debug.Log("Got it");
		source.clip = newClip;
		source.volume = 0.25f;
		source.time = 0.0f;
		source.Play();
		float timeLeft = source.clip.length - source.time;
		Invoke("NewSong", timeLeft);
	}
}
