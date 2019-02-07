using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "qteData", menuName = "Quicktime/QuicktimeEvent", order = 1)]
public class ScriptableQTE : ScriptableObject {
	public List<QuickTimeButton> buttons;
}
