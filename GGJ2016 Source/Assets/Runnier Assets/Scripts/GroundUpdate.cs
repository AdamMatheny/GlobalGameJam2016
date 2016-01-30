using UnityEngine;
using System.Collections;

public class GroundUpdate : MonoBehaviour {
	public float scrollSpeed = 0.5F;
	MeshRenderer rend;

	void Start() {
		rend=GetComponent<MeshRenderer>();
	}

	void Update() {
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
