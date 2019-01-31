using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "dialogueData", menuName = "Dialogue/DialogueTree", order = 1)]
public class ScriptableDialogueTree : ScriptableObject{
	public List<DialogueNode> nodes = new List<DialogueNode>();

}	
