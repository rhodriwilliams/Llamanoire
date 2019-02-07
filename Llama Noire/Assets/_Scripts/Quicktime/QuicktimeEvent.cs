using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuicktimeEvent : MonoBehaviour {
	public GameObject buttonPrefab;
	public ScriptableQTE qte;
	protected List<QuickTimeButton> buttons;
	protected float timeToPress;
	protected int buttonIndex;
	protected GameObject newButton;
	protected float startTime;
	protected float endTime;
	protected Text timerText;

	// Use this for initialization
	void Start () {
		timerText = GetComponentInChildren<Text>();
		ScriptableQTE newEvent = Instantiate(qte);
		buttons = newEvent.buttons;
		newButton = Instantiate(buttonPrefab, transform.position, Quaternion.identity);
		newButton.transform.SetParent(transform);
		newButton.GetComponent<Button>().onClick.AddListener(ClickButton);
		newButton.SetActive(false);
		startTime = Time.time;
	}
	
	void Update () {
		if(!newButton.activeInHierarchy){
			if(Time.time >= (startTime + buttons[buttonIndex].spawnTime)){
				Spawnbutton(buttons[buttonIndex]);
			}
		} else {
			timerText.text = (Time.time - startTime + buttons[buttonIndex].endTime).ToString();
			if(Time.time >= (startTime + buttons[buttonIndex].endTime)){
				Fail();
			}
		}
	}

	void Spawnbutton(QuickTimeButton button){
		newButton.transform.position = button.position;
		newButton.GetComponentInChildren<Text>().text = button.text;
		newButton.SetActive(true);
		endTime = startTime + button.endTime;
	}

	public void ClickButton(){
		newButton.SetActive(false);
		buttonIndex++;
		timerText.text = "Nice";
	}

	void Fail(){
		Debug.Log("Fail");
	}
}
