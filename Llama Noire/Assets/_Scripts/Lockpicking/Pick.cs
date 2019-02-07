using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour {
	protected Lockpicking lpScript {get; set;}
	public Lockpicking LpScript{
		get{
			return lpScript;
		}
		set{
			lpScript = value;
		}
	}
	[SerializeField]
	protected float outerRadius;
	[SerializeField]
	protected float innerRadius;
	[SerializeField]
	protected float speed;
	protected float min;
	protected float max;
	void Start(){
		min = Screen.height / 2 - outerRadius;
		max = Screen.height / 2 - innerRadius;
	}
	void Update () {
		//translate up and down to vertical input axis, clamped to be within the ring
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + Input.GetAxis("Vertical") * speed, min, max), transform.position.z);
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Danger"){
			lpScript.Fail();
		}
	}
}
