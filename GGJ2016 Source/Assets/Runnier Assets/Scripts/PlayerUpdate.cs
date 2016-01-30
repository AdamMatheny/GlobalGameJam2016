﻿using UnityEngine;
using System.Collections;

public class PlayerUpdate : MonoBehaviour {

	public Rigidbody2D rb2d;
	public int JumpForce=1;
	public float MoveSpeed=1f;
	bool CanJump=true;
	Animator anim;
	int animRun=Animator.StringToHash("PlayerRun");
	int animJumpUp=Animator.StringToHash("PlayerJumpUp");
	int animLanding=Animator.StringToHash("PlayerLanding");

	// Use this for initialization
	void Start () {
		anim=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		bool jump=Input.GetButtonDown("Fire1");

		//make the player when the jump button is pressed.
		if (jump==true && CanJump==true)
		{
			anim.Play(animJumpUp); CanJump=false;
			rb2d.AddForce(Vector2.up * (JumpForce*70) );
		}
		//when the player is falling, set the animation landing.
		if (rb2d.velocity.y<0 && CanJump==false)
		{anim.Play(animLanding);}

		rb2d.velocity=new Vector2(MoveSpeed,rb2d.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag=="Ground")
		{anim.Play(animRun); CanJump=true; }
		if (col.gameObject.tag=="Enemy")
		{Application.LoadLevel ("running_stage"); }
	}
	void OnCollisionExit2D(Collision2D col)
	{
		CanJump=false;
	}
}