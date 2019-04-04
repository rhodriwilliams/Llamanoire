using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTalkToMe : ObjectiveListener {

	protected override void CompleteObjective(){
		GetComponent<SphereCollider>().enabled = false;
	}
}
