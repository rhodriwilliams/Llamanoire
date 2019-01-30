﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class DialogueNode {

	[Header("Node")]

	public Sprite image;
	public string name;

	[TextArea]
	public string message;

	public DialogueOption[] options;

	public bool autoNext;
	public float nextTime = 0f;
	public int nextIndex;

	public bool succeed;
}
