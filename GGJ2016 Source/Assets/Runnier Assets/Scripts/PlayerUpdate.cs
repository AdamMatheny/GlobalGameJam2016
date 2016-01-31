using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUpdate : MonoBehaviour {

    public GameObject ammoKeeper;
	public AudioClip[] JumpAudioClip=new AudioClip[3];
	AudioSource audio;

	Rigidbody2D rb2d;
	GameObject BabyJumpTarget;
	BabyUpdate BU;
	public GameObject UIText;

	public bool currTrigger;
	public bool pastTrigger;
	public int TomatoCount=0;
	
	public int JumpForce=1;
	public float MoveSpeed=1f;
	bool CanJump=true;
	Animator anim;
	int animRun=Animator.StringToHash("PlayerRun");
	int animJumpUp=Animator.StringToHash("PlayerJumpUp");
	int animLanding=Animator.StringToHash("PlayerLanding");
	
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		anim=GetComponent<Animator>();
		rb2d=GetComponent<Rigidbody2D>();
		
		TomatoCount=0;
		//SetTomatoCountText();
	}
	
	// Update is called once per frame
	void Update () {
		bool jump=Input.GetButtonDown("Fire1");

		if (Input.GetAxis("AnalogRightBumper") > .5f)
		{			
			currTrigger = true;
		}
		else
		{			
			currTrigger = false;
		}
		
		if (currTrigger && !pastTrigger && CanJump)
		{			
			PlayRandomJumpClip();
			anim.Play(animJumpUp); CanJump = false;
			rb2d.AddForce(Vector2.up * (JumpForce * 70));
		}

		//make the player when the jump button is pressed.
		if (jump==true && CanJump==true)
		{
			PlayRandomJumpClip();
			anim.Play(animJumpUp); CanJump=false;
			rb2d.AddForce(Vector2.up * (JumpForce*70) );
		}
		//when the player is falling, set the animation landing.
		if (rb2d.velocity.y<0 && CanJump==false)
		{ anim.Play(animLanding); }
		
		//rb2d.velocity=new Vector2(MoveSpeed,rb2d.velocity.y);
		
		pastTrigger = currTrigger;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		BabyJumpTarget=other.transform.parent.gameObject;
		//BU=BabyJumpTarget.GetComponent<BabyUpdate>();
		
		if (BabyJumpTarget.tag=="Enemy" )
		{
			TomatoCount++; //SetTomatoCountText();
			//Application.LoadLevel("running_stage");
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		anim.Play(animRun);
		//if player collides with an enemy.
		if (col.gameObject.tag == "Enemy")
		{ ammoKeeper.GetComponent<Ammo>().ammo = TomatoCount; Application.LoadLevel(2); }
	}
	
	void OnCollisionStay2D(Collision2D col)
	{
		//if player collides with the ground
		if (col.gameObject.tag == "Ground")
		{  CanJump = true; }
		//if player collides with an enemy.
		if (col.gameObject.tag == "Enemy")
        { ammoKeeper.GetComponent<Ammo>().ammo = TomatoCount; Application.LoadLevel(2); }
    }
	
	void OnCollisionExit2D(Collision2D col)
	{
		CanJump=false;
	}

	void SetTomatoCountText()
	{
		UIText.GetComponent<Text>().text = ("x"+TomatoCount.ToString ()); //Display Health and Ammo	
	}

	void PlayRandomJumpClip()
	{
		int JType=Random.Range(0, 3);		
		audio.clip = JumpAudioClip[JType];
		audio.Play(); 
	}

}
		