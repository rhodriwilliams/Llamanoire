using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour {

	protected bool fading;
	protected Color targetColor;
	public Image image;

	protected float speed;

	public void FadeIn(float _speed){
		fading = true;
		targetColor = Color.clear;
		speed = _speed;
	}
	public void FadeOut(float _speed){
		fading = true;
		targetColor = Color.black;
		speed = _speed;
	}
	void Update(){
		if(fading){
			if(image.color != targetColor){
				image.color = Color.Lerp(image.color, targetColor, speed);
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
		FadeIn(0.2f);
    }

}
