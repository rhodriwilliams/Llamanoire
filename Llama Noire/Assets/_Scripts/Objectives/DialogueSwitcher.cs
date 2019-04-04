using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dialogue))]
public class DialogueSwitcher : ObjectiveListener {
	public ScriptableDialogueTree newTree;
	protected override void CompleteObjective(){
		GetComponent<Dialogue>().SwitchDialogue(newTree);
		//Debug.Log("I agree");
	}
}
