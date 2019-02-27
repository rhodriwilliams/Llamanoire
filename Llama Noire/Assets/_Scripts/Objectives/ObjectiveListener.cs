using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveListener : MonoBehaviour {
	public string objective;
	public int iTarget;

	void Start(){
		GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>().listeners.Add(this);
	}
	public void UpdateObj(bool b, int i){
		Debug.Log("ye");
		if(b || (i >= iTarget && iTarget > 0)){
			CompleteObjective();
		}
	}
	protected virtual void CompleteObjective(){

	}
	void OnDestroy(){
//		GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>().listeners.Remove(this);
	}
}
