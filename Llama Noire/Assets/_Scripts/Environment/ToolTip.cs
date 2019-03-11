using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

	private Text text;

	void Awake () {
		text = gameObject.GetComponent<Text>();
	}

	public void NewTip(string tip){
		text.text = tip;
	}

	public void ClearTip(){
		text.text = "";
	}

}
