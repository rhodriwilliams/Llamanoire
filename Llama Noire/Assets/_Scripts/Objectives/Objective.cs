using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "objectiveData", menuName = "Objectives/Objective", order = 1)]
public class Objective : ScriptableObject {
	public string objectiveName;
	public string objectiveMessage;
	public bool isHidden;
	public bool bCompleted;
	public int iCompleted;
	public int iToComplete;
	/*
	public Objective(string name, bool complete){
		objectiveName = name;
		bCompleted = complete;
	}
	public Objective(string name, int complete){
		objectiveName = name;
		iCompleted = complete;
	}
	*/
}
