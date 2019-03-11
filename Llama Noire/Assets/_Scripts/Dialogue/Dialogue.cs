using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class Dialogue : MonoBehaviour {

	public CinemachineVirtualCamera cam;
	public ScriptableDialogueTree dialogueTree;
	public GameObject dialoguePrefab;
	public Vector3 dialoguePos;
	public string[] animationBools;
	protected Animator animator;
	private GameObject instance;
	private Text speakerName;
	private Text message;
	private Image image;
	public Text[] buttonTexts = new Text[4];
	public List<DialogueNode> nodeList = new List<DialogueNode>();

	private ObjectiveManager objMan;

	private int currentNode;

	public void SwitchDialogue(ScriptableDialogueTree newTree){
		ScriptableDialogueTree tree = Instantiate(newTree);
		nodeList.Clear();
		for(int i = 0; i < tree.nodes.Count; i++){
			DialogueNode dn = tree.nodes[i];
			nodeList.Add(dn);
			for(int j = 0; j < dn.options.Length; j++){
				if(dn.options[j].nextNode > tree.nodes.Count){
					DialogueError(i, "Option ref " + j + " out of Range. Option will quit dialogue");
					dn.options[j].nextNode = -1;
				}
			}
		}
	}
	void Start(){
		objMan = GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>();

		SwitchDialogue(dialogueTree);
		
		animator = GetComponentInChildren<Animator>();
		//StartDialogue();
	}

	void Update(){
		if(nodeList[currentNode].options.Length == 0){
			if(Input.anyKeyDown){
				if(nodeList[currentNode].autoQuit)
					ExitDialogue();
				else
					DisplayNode(nodeList[currentNode].autoNextIndex);
			}
		}
	}
	
	void DialogueError(int node, string errorMessage){
		Debug.LogWarning(dialogueTree.name + ", Dialogue Node " + node + ": " + errorMessage + ".");
	}

	public void StartDialogue(){
		//instantiate a clone of the dialogue UI and place t on the canvas
		instance = Instantiate(dialoguePrefab, Vector3.zero, Quaternion.identity);
		instance.transform.SetParent(GameObject.Find("HUD").transform, false);
		instance.transform.localPosition = dialoguePos;

		//Find all the neccessary elements of the UI
		speakerName = GameObject.Find("_DialogueName").GetComponent<Text>();
		message = GameObject.Find("_DialogueMessage").GetComponent<Text>();
		image = GameObject.Find("_DialogueImage").GetComponent<Image>();

		//find the buttons and set up
		GameObject[] dbs = new GameObject[4];
		for (int i = 0; i < 4; i++){
			buttonTexts[i] = GameObject.Find("_ButtonText" + i.ToString()).GetComponent<Text>();
			dbs[i] = buttonTexts[i].transform.parent.gameObject;
		}
		foreach(GameObject go in dbs){
			go.GetComponent<Button>().onClick.AddListener(HandleButtonClick);
		}
		
		cam.Priority = 100;
		//display the first node
		DisplayNode(0);
	}
	public void DisplayNode(int nodeIndex){
		//get node from list and display it
		DialogueNode node = nodeList[nodeIndex];
		image.sprite = node.image;
		speakerName.text = node.name;
		message.text = node.message;

		if(node.options.Length == 0){
			//no options, that's ok
			for (int i = 0; i < 4; i++){
				buttonTexts[i].transform.parent.gameObject.SetActive(false);
			}
			/*
			if(!node.autoQuit){
				//no auto quit, that's still ok
				if(node.autoNextIndex == 0){
					//someone probably forgot to set the auto next. but that's ok.
					DialogueError(nodeIndex, "No options or auto quit and auto next index is 0. Did you forget something?");
				}
				IEnumerator coroutine = LoadAfterSeconds(node.autoNextIndex, node.autoTime);
				StartCoroutine(coroutine);
			}
			*/
		} else {
			for (int i = 0; i < 4; i++){
				if(i < node.options.Length){
					//set the option buttons' texts
					buttonTexts[i].transform.parent.gameObject.SetActive(true);
					buttonTexts[i].text = node.options[i].text;
				} else {
					//disable all buttons without options
					buttonTexts[i].transform.parent.gameObject.SetActive(false);
				}
			}
			
		}
		if(node.autoQuit){
			IEnumerator coroutine = ExitAfterSeconds(node.autoTime);
			StartCoroutine(coroutine);
		} else if (node.autoTime > 0f){
			//if autotime is set but autoquit is false, load the auto next
			IEnumerator coroutine = LoadAfterSeconds(node.autoNextIndex, node.autoTime);
			StartCoroutine(coroutine);
		}
		currentNode = nodeIndex;
	}

	public void HandleButtonClick(){ 
		//find the button that was clicked and open a new node accordingly
		int buttonNo = int.Parse(EventSystem.current.currentSelectedGameObject.name);
		DialogueOption option = nodeList[currentNode].options[buttonNo]; //find the dialogue option selected
		if(option.function == ""){ //for special dialogue actions like exiting and animation
			DisplayNode(option.nextNode);
		} else {
			SendMessage(option.function, option, SendMessageOptions.RequireReceiver);
		}

	}
	
	public void ExitDialogue(DialogueOption o){
		//exit dialogue through option
		Destroy(instance);
		//turn everything off
		gameObject.GetComponent<TalkativeNPC>().beingInteracted = false;
		cam.Priority = 0;
		GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>().ToggleCursor();

		if(o.objective != ""){ //complete objectives if applicable
			objMan.SetBool(o.objective, true);
		}
	}
	public void ExitDialogue(){
		//exit dialogue through auto quit
		Destroy(instance);
		gameObject.GetComponent<TalkativeNPC>().beingInteracted = false;
		cam.Priority = 0;
		GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>().ToggleCursor();
		if(nodeList[currentNode].objective != "") // complete objectives if applicable
			objMan.SetBool(nodeList[currentNode].objective, true);
	}

	public void RandomChance(DialogueOption o){
		if(Random.Range(1,11) > o.difficulty){
			DisplayNode(o.nextNode);
		} else {
			DisplayNode(o.failNode);
		}
	}

	public void Animation(DialogueOption o){
		//if(!animator.GetBool(animationBools[o.difficulty])){
		//	Debug.Log("Yeah boi");
		//	animator.SetBool(animationBools[o.difficulty], true);
		//}
		animator.SetTrigger(animationBools[o.difficulty]);
		DisplayNode(o.nextNode);
	}

	IEnumerator LoadAfterSeconds(int i, float waitTime){
		yield return new WaitForSeconds(waitTime);
		DisplayNode(i);
	}
	IEnumerator ExitAfterSeconds(float waitTime){
		yield return new WaitForSeconds(waitTime);
		ExitDialogue();
	}
}
