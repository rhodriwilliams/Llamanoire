using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectiveDisplay : MonoBehaviour {
	public Text text;
	public Text cluesText;
	public ObjectiveManager manager;
	public int maxClues;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		cluesText = GameObject.Find("Clues").GetComponent<Text>();
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>();
	}
	
	public void UpdateText(){
		cluesText.text = "Find Clues: " + manager.GetInt("Clues") + "/" + maxClues;
		text.text = manager.PrintObjectives();
	}
}
