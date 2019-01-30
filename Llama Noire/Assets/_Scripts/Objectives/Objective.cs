using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "objectiveData", menuName = "Objectives/Objective", order = 1)]
public class Objective : ScriptableObject {
	public string objectiveName;
	public bool bCompleted;
	public int iCompleted;
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
