using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveListener : MonoBehaviour {
	public string objective;
	public int iTarget;
	protected ObjectiveManager manager;
	void Start(){
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>();
		manager.listeners.Add(this);
		UpdateObj(manager.GetBool(objective), manager.GetInt(objective));
	}
	public void UpdateObj(bool b, int i){
		//Debug.Log("ye");
		if(b || (i >= iTarget && iTarget > 0)){
			CompleteObjective();
		}
	}
	protected virtual void CompleteObjective(){

	}
	void OnDestroy(){
		if(GameObject.FindGameObjectWithTag("Manager")){
			GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>().listeners.Remove(this);
		}
	}
}
