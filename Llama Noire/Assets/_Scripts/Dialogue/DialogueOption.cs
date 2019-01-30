using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DialogueOption {
	[Header("Option")]
	[TextArea]
	public string text;
	public int nextNode;

	public string function = "";

	public int difficulty = 1;
	public int failNode;
	public bool succeed;
}
