using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ObjectiveListener {

	protected ToolTip toolTip;
	protected bool hasKey;

	void Awake()
	{
		toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<ToolTip>();
	}
	protected override void CompleteObjective(){
		hasKey = true;
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && hasKey){
			Destroy(gameObject);
		} else {
			toolTip.NewTip("Door (I need a key)");
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			toolTip.ClearTip();
		}
	}
}
