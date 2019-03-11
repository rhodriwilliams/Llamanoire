using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

	public List<ObjectiveListener> listeners = new List<ObjectiveListener>();
	public List<Objective> objectives = new List<Objective>();

	public bool GetBool(string key){
		foreach(Objective o in objectives){
			if(o.objectiveName == key){
				return o.bCompleted;
			}
		}
		return false;
	}

	public int GetInt(string key){
		foreach(Objective o in objectives){
			if(o.objectiveName == key){
				return o.iCompleted;
			}
		}
		return 0;
	}

	public void SetBool(string key, bool complete){
		Debug.Log("Objective Complete: " + key);
		foreach(Objective o in objectives){
			if(o.objectiveName == key){
				o.bCompleted = complete;
				UpdateListeners(key);
				return;
			}
		}
	}

	public void SetInt(string key, int complete){
		foreach(Objective o in objectives){
			if(o.objectiveName == key){
				o.iCompleted = complete;
				UpdateListeners(key);
				return;
			}
		}
	}

	public void SetHidden(string key, bool hidden){
		foreach(Objective o in objectives){
			if(o.objectiveName == key){
				o.isHidden = hidden;
				UpdateListeners(key);
				return;
			}
		}
	}
	void UpdateListeners(string key){
		foreach (ObjectiveListener ol in listeners){
			if (ol.objective == key){
				ol.UpdateObj(GetBool(key), GetInt(key));
			}
		}
	}

	public string PrintObjectives(){
		string print = "Objectives: " + "\n";
		foreach(Objective o in objectives){
			if(!o.bCompleted && !o.isHidden){
				print += o.objectiveMessage + "\n";

			}
		}
		return print;
	}
}
