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

	private GameObject instance;
	private Text speakerName;
	private Text message;
	private Image image;
	public Text[] buttonTexts = new Text[4];
	public List<DialogueNode> nodeList = new List<DialogueNode>();

	private ObjectiveManager objMan;

	private int currentNode;


	void Start(){


		objMan = GameObject.FindGameObjectWithTag("Manager").GetComponent<ObjectiveManager>();
	
		ScriptableDialogueTree tree = Instantiate(dialogueTree);

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
		//StartDialogue();
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
			for (int i = 0; i < 4; i++){
				buttonTexts[i].transform.parent.gameObject.SetActive(false);
			}
			if(node.autoNext){
				IEnumerator coroutine = LoadAfterSeconds(node.nextIndex, node.nextTime);
				StartCoroutine(coroutine);
			} else {
				IEnumerator coroutine = ExitAfterSeconds(node.nextTime);
				StartCoroutine(coroutine);
			}
		} else {
			for (int i = 0; i < 4; i++){
				if(i < node.options.Length){
					buttonTexts[i].transform.parent.gameObject.SetActive(true); //delete this
					buttonTexts[i].text = node.options[i].text;
				} else {
					buttonTexts[i].transform.parent.gameObject.SetActive(false);
				}
			}
			
		}
		
		currentNode = nodeIndex;
	}

	public void HandleButtonClick(){ 
		//find the button that was clicked and open a new node accordingly
		int buttonNo = int.Parse(EventSystem.current.currentSelectedGameObject.name);
		DialogueOption option = nodeList[currentNode].options[buttonNo]; //find the dialogue option selected
		if(option.function == ""){ // -1 is exit dialogue. hopefully temporarily, probably permanently. update: hey grats to me for changing it
			DisplayNode(option.nextNode);
		} else {
			SendMessage(option.function, option);
		}

	}
	
	public void ExitDialogue(DialogueOption o){
		Destroy(instance);
		gameObject.GetComponent<TalkativeNPC>().beingInteracted = false;
		cam.Priority = 0;
		GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>().ToggleCursor();
		objMan.SetBool(dialogueTree.objectiveName, o.succeed);
	}
	public void ExitDialogue(){
		Destroy(instance);
		gameObject.GetComponent<TalkativeNPC>().beingInteracted = false;
		cam.Priority = 0;
		GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>().ToggleCursor();
		objMan.SetBool(dialogueTree.objectiveName, nodeList[currentNode].succeed);
	}

	public void RandomChance(DialogueOption o){
		if(Random.Range(1,11) > o.difficulty){
			DisplayNode(o.nextNode);
		} else {
			DisplayNode(o.failNode);
		}
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
