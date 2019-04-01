using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class Tutorial : MonoBehaviour {

	[SerializeField]
	protected CinemachineVirtualCamera tutorialCam;
	protected GameObject player;
	[SerializeField]
	protected GameObject creditCanvas;
	protected int tutorialState = 0;
	[SerializeField]
	protected Text helperText;
	protected ObjectiveManager manager;
	void Start(){
		/*
		helperText = GameObject.Find("HelperText").GetComponent<Text>();
		player = GameObject.FindGameObjectWithTag("Player");
		tutorialCam = GameObject.Find("TutorialCam").GetComponent<CinemachineVirtualCamera>();
		creditCanvas = GameObject.Find("Title");
	
		Invoke("BeginHelp", 5f);
		*/
			manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>();
	}
	void Update () {
		/*
		switch(tutorialState){
		case 0:
			if(Input.anyKeyDown){
				CancelInvoke();
				helperText.text = "";
				tutorialState++;
				tutorialCam.Priority = 0;
				player.GetComponent<RhunCharacter>().busy = false;
				player.GetComponentInChildren<Animator>().SetBool("InMenu", false);
				Destroy(creditCanvas);
				Invoke("Controls", 5f);
			}
			break;
		case 1:
			if(Input.anyKeyDown){
				CancelInvoke();
				helperText.text = "";
				tutorialState++;
			}
			break;
		default:
			break;
		}*/
		if(manager.IsHidden("FindWayOut")){
			if(manager.GetBool("InvestigateScene") && manager.GetBool("FindWeapon")){
				manager.SetHidden("FindWayOut", false);
			}
		}
	}
	void BeginHelp(){
		helperText.text = "Press any key to continue";
	}
	void Controls(){
		helperText.text = "Use the W A S and D keys to move";
	}
}
