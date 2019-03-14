using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SplashScreen : MonoBehaviour {
	protected Image img;
	protected Color targetColor;
	[SerializeField]
	protected GameObject[] objectsToEnable;
	void Start(){
		SceneManager.sceneLoaded += OnSceneLoaded;
		img = GetComponent<Image>();
		targetColor = Color.white;
	}
	void Update(){
		if(img.color != targetColor){
			img.color = Color.Lerp(img.color, targetColor, 0.1f);
		} else if(targetColor == Color.white){
			targetColor = Color.clear;
		} else {
			
			foreach(GameObject go in objectsToEnable){
				go.SetActive(true);
			}
			SceneManager.LoadScene("Apartment");
		}
	}
	public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		if(scene.name == "Apartment"){
			
		}
	}
}
