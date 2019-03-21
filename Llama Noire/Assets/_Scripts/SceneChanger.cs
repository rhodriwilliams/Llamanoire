using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class SceneChanger : MonoBehaviour {

	protected GameObject player;
	protected FadeInOut fader;
	protected string cameFrom = "";
	protected ObjectiveManager objectiveManager;
	protected Tutorial tutScript;
	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player");
		fader = GameObject.FindGameObjectWithTag("FadeInOut").GetComponent<FadeInOut>();
		SceneManager.sceneLoaded += OnSceneLoaded;
		objectiveManager = GetComponent<ObjectiveManager>();
		tutScript = GetComponent<Tutorial>();
	}

	public void LoadScene(string _sceneName, string _cameFrom){
		cameFrom = _cameFrom;
		player.GetComponent<RhunCharacter>().busy = true;
		SceneManager.LoadSceneAsync(_sceneName);
		fader.FadeOut(0.2f);
	}
	public void LoadScene(string _sceneName){
		cameFrom = "";
		player.GetComponent<RhunCharacter>().busy = true;
		SceneManager.LoadSceneAsync(_sceneName);
		fader.FadeOut(0.2f);
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		player = GameObject.FindGameObjectWithTag("Player");
		GameObject.FindGameObjectWithTag("ToolTip").GetComponent<ToolTip>().ClearTip();
		//Debug.Log("Came from " + cameFrom);
		if(cameFrom != ""){
			player.transform.position = GameObject.Find(cameFrom).transform.position;
			player.transform.rotation = GameObject.Find(cameFrom).transform.rotation;
		}
		if(scene.name != "Tutorial"){
			player.GetComponent<RhunCharacter>().busy = false;
			player.GetComponentInChildren<Animator>().SetBool("InMenu", false);
		} else if(cameFrom != ""){
			Destroy(GameObject.Find("Menu"));
			GameObject.Find("CM menuCam").GetComponent<CinemachineVirtualCamera>().Priority = 0;
			player.GetComponent<RhunCharacter>().busy = false;
			player.GetComponentInChildren<Animator>().SetBool("InMenu", false);
		}
		if(scene.name == "InteriorSpeakeasyWhitebox"){
			objectiveManager.SetHidden("GetUpstairs", false);
			objectiveManager.SetBool("GetInSpeakeasy", true);
		} else if(scene.name == "Tutorial"){
			objectiveManager.SetBool("Sleep", true);
			//tutScript.enabled = true;
		} else if (scene.name == "Apartment"){
			if(objectiveManager.GetBool("Sleep")){
				objectiveManager.SetHidden("GetInSpeakeasy", false);
				objectiveManager.SetHidden("FindPacone", false);
			}
		}
	}
}
