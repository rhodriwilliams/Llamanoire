using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {
	protected RhunCharacter chara;
	protected CameraBoom camBoom;

	void Start(){
		chara = GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>();
		camBoom = GameObject.Find("Camera Boom").GetComponent<CameraBoom>();
	}
	public void SetVolume(float value){
	
	}
	public void SetSensitivity(float value){
		camBoom.sensitivity = value;
	}
	public void SetInvert(bool value){
		camBoom.inverted = value;
	}
	public void SetQuality(int value){
		QualitySettings.SetQualityLevel(value, true);
	}
}
