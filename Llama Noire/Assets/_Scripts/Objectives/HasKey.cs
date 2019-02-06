using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasKey : ObjectiveListener {

	protected ToolTip toolTip;
	protected bool hasKey {get;set;}
	public bool HaveKey {
		get
		{
			return hasKey;
		}
	}

	void Awake()
	{
		toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<ToolTip>();
	}
	protected override void CompleteObjective(){
		hasKey = true;
	}
}
