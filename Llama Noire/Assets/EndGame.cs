using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGame : ObjectiveListener {

	[SerializeField]
	protected string[] objectives;
	protected int ending;

	[SerializeField]
	protected GameObject shootEndPrefab;
	[SerializeField]
	protected GameObject throwEndPrefab;
	[SerializeField]
	protected Transform shootEndTransform;
	[SerializeField]
	protected Transform throwEndTransform;

	protected GameObject llamas;
	protected SceneChanger changer;
	void Awake(){
		changer = GameObject.FindGameObjectWithTag("Manager").GetComponent<SceneChanger>();
		llamas = GameObject.Find("_ANIMATED_LLAMAS");
	}

	public override void UpdateObj(bool b, int i ){
		for(int j = 0; j < objectives.Length; j++){
			if(manager.GetBool(objectives[j])){
				ending = j;
				CompleteObjective();
			}
		}
	}
	protected override void CompleteObjective(){
		GameObject.FindGameObjectWithTag("Player").GetComponent<RhunCharacter>().ToggleCursor();
		switch (ending){
		case 0:
			Destroy(GameObject.Find("OfficeWindow"));
			Destroy(llamas);
			Instantiate(throwEndPrefab, throwEndTransform.position, throwEndTransform.rotation);
			break;
		case 1:
			changer.LoadScene("ExteriorSpeakeasyWhitebox", "EndGame");
			break;
		case 2:
			
			break;
		case 3:
			Destroy(llamas);
			Instantiate(shootEndPrefab, shootEndTransform.position, shootEndTransform.rotation);
			break;
		default:
			break;
		}
	}
}
