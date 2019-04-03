using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpicking : MonoBehaviour {
	[SerializeField]
	protected GameObject pickPrefab;
	[SerializeField]
	protected GameObject pick;
	protected Lock lockScript {get; set;}
	public Lock LockScript {
		get{
			return lockScript;
		}
		set{
			lockScript = value;
		}
	}
	[SerializeField]
	protected GameObject dangerPrefab;
	[SerializeField]
	protected float outerRadius;
	[SerializeField]
	protected float innerRadius;
	protected float turned;
	protected AudioSource source;

	[SerializeField]
	protected AudioClip lockStartSound;
	[SerializeField]
	protected AudioClip lockLoop;
	[SerializeField]
	protected AudioClip lockWinSound;

	public void Setup(int numToSpawn){
		source = GetComponent<AudioSource>();
		//instantiate pick object
		pick = Instantiate(pickPrefab, transform.position, Quaternion.identity);
		pick.GetComponent<Pick>().LpScript= this;
		if(GameObject.FindGameObjectWithTag("HUD")){
			//set up transforms
			transform.SetParent(GameObject.FindGameObjectWithTag("HUD").transform);
			pick.transform.SetParent(GameObject.FindGameObjectWithTag("HUD").transform);
			transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
			pick.transform.position = transform.position;
		}
		//spawn "danger" objects
		for(int i = 0; i < numToSpawn; i++){
			//random chance of being on the inner or outer edge of the ring
			bool top = (Random.value > 0.5);
			float yPos =  (top ? innerRadius : outerRadius);
			Vector3 newPos = transform.position + new Vector3(0f, yPos, 0f);
			GameObject newObject = Instantiate(dangerPrefab, newPos, Quaternion.identity);
			newObject.transform.SetParent(transform);
			//distribute evenly around the circle
			float rotation = (360f / numToSpawn) * i;
			newObject.transform.RotateAround(transform.position, Vector3.forward, rotation);
		}
	}
	void Update () {
		if(!source.isPlaying){
			StartLoop();
		} else if(source.clip == lockLoop){
			source.volume = Mathf.Abs(Input.GetAxis("Horizontal"));
		}
		//rotate with horizontal input axis
		if(turned - Input.GetAxis("Horizontal") > 0){
			transform.Rotate(0f, 0f, -Input.GetAxis("Horizontal"));
			turned -= Input.GetAxis("Horizontal");
		}
		if(turned >= 360f){
			//end minigame after full rotation
			source.clip = lockWinSound;
			source.loop = false;
			source.Play();
			lockScript.LockpickingComplete(true);
			Destroy(pick);
			Destroy(gameObject);
		}
	}
	public void Fail(){
		//called by pick object on collision with danger object
		lockScript.LockpickingComplete(false);
		Destroy(pick);
		Destroy(gameObject);
	}
	void StartLoop(){
		source.clip = lockLoop;
		source.loop = true;
		source.Play();
	}
}
