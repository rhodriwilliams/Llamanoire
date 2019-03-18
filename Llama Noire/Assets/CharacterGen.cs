using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class CharacterGen : MonoBehaviour {

	[SerializeField]
	protected Mesh[] clothes;

	[SerializeField]
	protected Material[] shirts;
	[SerializeField]
	protected Material[] suitShirts;
	[SerializeField]
	protected Material[] trousers;
	[SerializeField]
	protected Material[] suitTrousers;
	[SerializeField]
	protected Material[] furs;

	protected MeshRenderer _renderer;
	protected MeshFilter filter;
	// Use this for initialization
	void Start () {
		_renderer = GetComponent<MeshRenderer>();
		filter = GetComponent<MeshFilter>();
		int[] materialIndexes; // shirt, trousers, fur
		int clothesIndex = Random.Range(0, clothes.Length);
		if(clothesIndex == 0){
			materialIndexes = new int[] {2, 0 , 1};
			filter.mesh = Instantiate(clothes[clothesIndex]);
			Material[] newMaterials = new Material[3];
			newMaterials[materialIndexes[0]] = Instantiate(suitShirts[Random.Range(0, suitShirts.Length)]);
			newMaterials[materialIndexes[1]] = Instantiate(suitTrousers[Random.Range(0, suitTrousers.Length)]);
			newMaterials[materialIndexes[2]] = Instantiate(furs[Random.Range(0, furs.Length)]);
			_renderer.materials = newMaterials;
		} else {
			materialIndexes = new int[] {1, 2, 0};
			filter.mesh = Instantiate(clothes[clothesIndex]);
			Material[] newMaterials = new Material[3];
			newMaterials[materialIndexes[0]] = Instantiate(shirts[Random.Range(0, shirts.Length)]);
			newMaterials[materialIndexes[1]] = Instantiate(trousers[Random.Range(0, trousers.Length)]);
			newMaterials[materialIndexes[2]] = Instantiate(furs[Random.Range(0, furs.Length)]);
			_renderer.materials = newMaterials;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
