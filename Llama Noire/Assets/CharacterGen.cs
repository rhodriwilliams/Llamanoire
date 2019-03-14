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
	protected Material[] trousers;
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
			materialIndexes = new int[] {1, 0 ,2};
		} else {
			materialIndexes = new int[] {1, 2, 0};
		}
		filter.mesh = clothes[clothesIndex];
		_renderer.materials[materialIndexes[0]] = shirts[Random.Range(0, shirts.Length)];
		_renderer.materials[materialIndexes[1]] = trousers[Random.Range(0, trousers.Length)];
		_renderer.materials[materialIndexes[2]] = furs[Random.Range(0, furs.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
