using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	public bool isPaused = false;
	public GameObject pauseMenu;
	private RhunCharacter chara;
	public ObjectiveDisplay display;

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
					AudioListener.pause = true;
					display.UpdateText();
				} else {
					chara.ToggleCursor();
					Time.timeScale = 1f;
					pauseMenu.SetActive(false);
					isPaused = false;
					AudioListener.pause = false;
					
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
			AudioListener.pause = false;
		}
	}

	public void Quit(){
		Application.Quit();
	}
}
