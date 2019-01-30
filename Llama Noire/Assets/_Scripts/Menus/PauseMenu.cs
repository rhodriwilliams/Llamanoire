using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	public bool isPaused = false;
	public GameObject pauseMenu;
	private RhunCharacter chara;

	void Start(){
		chara = GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		chara = GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>();
	}
	void Update () {
		if(!chara.busy){
			if(Input.GetButtonDown("Cancel")){
				if(!isPaused){
					chara.ToggleCursor();
					Time.timeScale = 0f;
					pauseMenu.SetActive(true);
					isPaused = true;
				} else {
					chara.ToggleCursor();
					Time.timeScale = 1f;
					pauseMenu.SetActive(false);
					isPaused = false;
				}
			}
		}
	}
	public void Resume(){
		if(isPaused){
			chara.ToggleCursor();
			Time.timeScale = 1f;
			pauseMenu.SetActive(false);
			isPaused = false;
		}
	}

	public void Quit(){
		Application.Quit();
	}
}
