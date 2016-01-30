using UnityEngine;
using System.Collections;

public class BabyUpdate : MonoBehaviour {

	Rigidbody2D rb2d;
	public float MoveSpeed=1f;

	// Use this for initialization
	void Start () {
		rb2d=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		
		rb2d.velocity=new Vector2(MoveSpeed,0);
	}
}
