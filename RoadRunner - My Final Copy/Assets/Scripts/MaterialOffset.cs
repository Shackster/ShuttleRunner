using UnityEngine;
using System.Collections;

public class MaterialOffset : MonoBehaviour {
	public float offset = 20f;
	public Renderer rend;
	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		rend.material.mainTextureOffset = new Vector2(0, offset);
	}
}
