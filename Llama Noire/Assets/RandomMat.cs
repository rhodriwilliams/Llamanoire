using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMat : MonoBehaviour {

	[SerializeField]
	protected Material[] mats;

	protected SkinnedMeshRenderer _renderer;

	// Use this for initialization
	void Start () {
		_renderer = GetComponentInChildren<SkinnedMeshRenderer>();
		Material[] newMats = new Material[] {mats[Random.Range(0, mats.Length)]};
		_renderer.materials = newMats;
	}
}
