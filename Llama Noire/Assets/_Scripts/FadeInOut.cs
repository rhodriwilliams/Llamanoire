using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour {

	protected bool fading;
	protected Color targetColor;
	public Image image;

	public void FadeIn(){
		fading = true;
		targetColor = Color.clear;
	}
	public void FadeOut(){
		fading = true;
		targetColor = Color.black;
	}
	void Update(){
		if(fading){
			if(image.color != targetColor){
				image.color = Color.Lerp(image.color, targetColor, 0.2f);
			}
			else {
				fading = false;
			}
		}
	}
	void Awake(){
		SceneManager.sceneLoaded += OnSceneLoaded;
		image.enabled = true;
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		FadeIn();
    }

}
