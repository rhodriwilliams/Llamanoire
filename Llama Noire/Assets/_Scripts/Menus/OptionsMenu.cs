using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour {
	protected RhunCharacter chara;
	protected CameraBoom camBoom;

	public Slider volumeSlider;
	public Slider sensitivitySlider;
	public Toggle invertToggle;
	public Dropdown qualityDropdown;
	void Start(){
		chara = GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>();
		camBoom = GameObject.Find("Camera Boom").GetComponent<CameraBoom>();
		float newVolume = PlayerPrefs.GetFloat("Volume", 1f);
		SetVolume(newVolume);
		volumeSlider.value = newVolume;
		float newSensitivity = PlayerPrefs.GetFloat("Sensitivity", 0.5f);
		SetSensitivity(newSensitivity);
		sensitivitySlider.value = newSensitivity;
		bool newInvert = (PlayerPrefs.GetInt("InvertLook", 0) == 1);
		SetInvert(newInvert);
		invertToggle.isOn = newInvert;
		int newQuality = PlayerPrefs.GetInt("Quality", 5);
		SetQuality(newQuality);
		qualityDropdown.value = newQuality;
	}
	public void SetVolume(float value){
		AudioListener.volume = value;
		PlayerPrefs.SetFloat("Volume", value);
	}
	public void SetSensitivity(float value){
		camBoom.sensitivity = 0.1f + (camBoom.defaultSensitivity * value);
		PlayerPrefs.SetFloat("Sensitivity", value);
	}
	public void SetInvert(bool value){
		camBoom.inverted = value;
		PlayerPrefs.SetInt("InvertLook", (value ? 1 : 0));
	}

	public void SetQuality(int value){
		QualitySettings.SetQualityLevel(value, true);
		PlayerPrefs.SetInt("Quality", value);
	}
}
