using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGame : ObjectiveListener {

	[SerializeField]
	protected string[] objectives;

	[SerializeField]
	protected string[] endTexts;

	protected int ending;
	protected GameObject endSplash;
	protected Text splashText;
	void Awake(){
		endSplash = GameObject.Find("EndSplash");
		splashText = endSplash.GetComponentInChildren<Text>();
		endSplash.SetActive(false);
	}

	public override void UpdateObj(bool b, int i ){
		for(int j = 0; j < objectives.Length; j++){
			if(manager.GetBool(objectives[j])){
				ending = j;
				CompleteObjective();
			}
		}
	}
	protected override void CompleteObjective(){
		endSplash.SetActive(true);
		splashText.text = endTexts[ending];
	}
	// Update is called once per frame
	void Update () {
		
	}
}
