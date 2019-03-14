using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneManager : MonoBehaviour {

	public Rigidbody pacone;
	public CinemachineVirtualCamera faceCam;
	public CinemachineVirtualCamera dollyCam;
	// Use this for initialization
	void Start () {
		//faceCam.Priority = 10;
		Time.timeScale = 0.1f;
		pacone.AddForce(0f,1000f,-1000f);
		//Invoke("CutToDolly", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(dollyCam.Priority > 0){
			dollyCam.transform.position += new Vector3(0f, Time.deltaTime, 0f);
		}
	}
	void CutToDolly(){
		faceCam.Priority = 0;
		dollyCam.Priority = 10;
	}
}
