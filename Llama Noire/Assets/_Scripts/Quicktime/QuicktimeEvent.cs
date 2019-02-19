using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuicktimeEvent : MonoBehaviour {
	public TestQTE owner;
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
	public void Setup(ScriptableQTE scriptableQTE, TestQTE _owner) {
		owner = _owner;
		transform.SetParent(GameObject.Find("HUD").transform, false);
		timerText = GetComponentInChildren<Text>();
		ScriptableQTE newEvent = Instantiate(scriptableQTE);
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
			timerText.text = (startTime + buttons[buttonIndex].endTime - Time.time).ToString();
			if(Time.time >= (startTime + buttons[buttonIndex].endTime)){
				Fail();
			}
		}
	}

	void Spawnbutton(QuickTimeButton button){
		button.size = newButton.GetComponent<RectTransform>().rect.size;

		float newX = (GetComponent<RectTransform>().rect.width / 100 * button.position.x) - button.size.x;
		float newY = (GetComponent<RectTransform>().rect.height / 100 * button.position.y) - button.size.y;

		newButton.transform.position = new Vector3(newX, newY, 0f);
		newButton.GetComponentInChildren<Text>().text = button.text;
		newButton.SetActive(true);
		endTime = startTime + button.endTime;
	}

	public void ClickButton(){
		newButton.SetActive(false);
		buttonIndex++;
		if(buttonIndex >= buttons.Count){
			Destroy(gameObject);
			owner.EndQTE();
		}
		timerText.text = "Nice";
	}

	void Fail(){
		Destroy(gameObject);
		owner.EndQTE();
	}
}
