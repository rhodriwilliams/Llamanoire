using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Menu : MonoBehaviour {
	protected bool mainMenu = true;

	public GameObject hud;
	public GameObject armstrong;
	public CinemachineVirtualCamera menuCam;
	public CinemachineVirtualCamera optionsCam;
	public CinemachineVirtualCamera creditsCam;
	
	public GameObject audioMenu;
	public GameObject gameplayMenu;
	public GameObject graphicsMenu;
	void Start () {
		armstrong = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	public void Play(){
		if(mainMenu){
			hud.SetActive(true);
			menuCam.Priority = 0;
			armstrong.GetComponent<RhunCharacter>().ToggleCursor();
			armstrong.GetComponentInChildren<Animator>().SetBool("InMenu", false);
			Destroy(gameObject);
		}
	}

	public void Options(){
		if(mainMenu){
			optionsCam.Priority = 10;
			mainMenu = false;
		}
	}
	public void Audio(){
		audioMenu.SetActive(true);
		gameplayMenu.SetActive(false);
		graphicsMenu.SetActive(false);
	}
	public void Gameplay(){
		audioMenu.SetActive(false);
		gameplayMenu.SetActive(true);
		graphicsMenu.SetActive(false);
	}
	public void Graphics(){
		audioMenu.SetActive(false);
		gameplayMenu.SetActive(false);
		graphicsMenu.SetActive(true);
	}

	public void Credits(){
		if(mainMenu){
			creditsCam.Priority = 10;
			mainMenu = false;
		}
	}

	public void Quit(){
		Application.Quit();
	}

	public void Back(){
		mainMenu = true;
		menuCam.Priority = 10;
		optionsCam.Priority = 0;
		creditsCam.Priority = 0;
		audioMenu.SetActive(false);
		gameplayMenu.SetActive(false);
		graphicsMenu.SetActive(false);
	}
}
