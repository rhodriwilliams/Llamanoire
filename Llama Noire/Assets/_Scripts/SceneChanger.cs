using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	protected GameObject player;
	protected FadeInOut fader;
	protected string cameFrom = "";

	void Awake(){
		//player = GameObject.FindGameObjectWithTag("Player");
		fader = GameObject.FindGameObjectWithTag("FadeInOut").GetComponent<FadeInOut>();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public void LoadScene(string _sceneName, string _cameFrom){
		cameFrom = _cameFrom;
		player.GetComponent<RhunCharacter>().busy = true;
		SceneManager.LoadSceneAsync(_sceneName);
		fader.FadeOut();
	}
	public void LoadScene(string _sceneName){
		cameFrom = "";
		player.GetComponent<RhunCharacter>().busy = true;
		SceneManager.LoadSceneAsync(_sceneName);
		fader.FadeOut();
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		player = GameObject.FindGameObjectWithTag("Player");
		Debug.Log("Came from " + cameFrom);
		if(cameFrom != ""){
			player.transform.position = GameObject.Find(cameFrom).transform.position;
			player.transform.rotation = GameObject.Find(cameFrom).transform.rotation;
		}
	}
}
