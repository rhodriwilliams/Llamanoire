using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrumpetListener : ObjectiveListener {
	protected override void CompleteObjective(){
		manager.SetHidden("FindWayOut", false);
		Destroy(gameObject);
	}

}
