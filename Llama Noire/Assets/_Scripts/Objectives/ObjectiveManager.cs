using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectiveManager : MonoBehaviour {
	[HideInInspector]
	public List<ObjectiveListener> listeners = new List<ObjectiveListener>();
	public List<Objective> objectives = new List<Objective>();
	protected List<Objective> currentObjectives = new List<Objective>();

	void Awake(){
		for(int i = 0; i < objectives.Count; i++){
			currentObjectives.Add(Instantiate(objectives[i]));
		}
	}
	public bool GetBool(string key){
		foreach(Objective o in currentObjectives){
			if(o.objectiveName == key){
				return o.bCompleted;
			}
		}
		return false;
	}

	public int GetInt(string key){
		foreach(Objective o in currentObjectives){
			if(o.objectiveName == key){
				return o.iCompleted;
			}
		}
		return 0;
	}

	public void SetBool(string key, bool complete){
		foreach(Objective o in currentObjectives){
			if(o.objectiveName == key){
				o.bCompleted = complete;
				UpdateListeners(key);
				return;
			}
		}
		Debug.LogWarning("Objective " + key + " not found");
	}

	public void SetInt(string key, int complete){
		foreach(Objective o in currentObjectives){
			if(o.objectiveName == key){
				o.iCompleted = complete;
				UpdateListeners(key);
				return;
			}
		}
	}

	public void SetHidden(string key, bool hidden){
		foreach(Objective o in currentObjectives){
			if(o.objectiveName == key){
				o.isHidden = hidden;
				UpdateListeners(key);
				return;
			}
		}
	}
	void UpdateListeners(string key){
		foreach (ObjectiveListener ol in listeners){
			if(key != ""){
			if (ol.objective == key){
				ol.UpdateObj(GetBool(key), GetInt(key));
			}
			} else {
				ol.UpdateObj(GetBool(ol.objective), GetInt(ol.objective));
			}
		}
	}

	public string PrintObjectives(){
		string print = "Objectives: " + "\n";
		foreach(Objective o in currentObjectives){
			if(!o.bCompleted && !o.isHidden){
				print += o.objectiveMessage + "\n";

			}
		}
		return print;
	}
}
