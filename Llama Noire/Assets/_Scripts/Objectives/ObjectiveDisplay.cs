using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectiveDisplay : MonoBehaviour {
	public Text text;
	public ObjectiveManager manager;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>();
	}
	
	public void UpdateText(){
		
		text.text = manager.PrintObjectives();
	}
}
