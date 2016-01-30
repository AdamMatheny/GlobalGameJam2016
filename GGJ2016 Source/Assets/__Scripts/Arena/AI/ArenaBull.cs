using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaBull : MonoBehaviour 
{
	[HideInInspector]public float mExitTimer = 1f;
	public ArenaPlayer mTargetPlayer;
	[SerializeField] private GameObject mLookTarget;
	[SerializeField] private float mSpeed = 7f;
	

	// Use this for initialization
	void Start () 
	{
		if(mTargetPlayer == null)
		{
			mTargetPlayer = FindObjectOfType<ArenaPlayer>();
		}
		mLookTarget = mTargetPlayer.gameObject;
		LookAtTarget();
	}
	
	// Update is called once per frame
	void Update () 
	{


		if(mExitTimer >0f)
		{
			mExitTimer-=Time.deltaTime;
			if (mExitTimer >=0.8f)
			{
				LookAtTarget();
			}
			if(mExitTimer <= 0.9f)
			{
				GetComponent<BoxCollider2D>().isTrigger = false;
			}
		}


		transform.Translate (0f,Time.deltaTime*mSpeed,0f);

	}

	void LookAtTarget()
	{
		if(mLookTarget != null)
		{
			float angle = 0;
			
			Vector3 relative = transform.InverseTransformPoint(mLookTarget.transform.position);
			angle = Mathf.Atan2(relative.x, relative.y)*Mathf.Rad2Deg;
			transform.Rotate(0,0, -angle);
		}
	}

	//Go to a gate after ramming into a wall ~Adam
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if(coll.gameObject.layer == 12) //Layer 12 should be the ArenaWall layer
		{
			List<BullExit> exitList = FindObjectOfType<ArenaBullSpawner>().mBullExits;
			GameObject nearestExit = exitList[0].gameObject;
			float exitDist = 1000f;

			foreach(BullExit exit in exitList)
			{
				if( Vector2.Distance (this.gameObject.transform.position, exit.transform.position) < exitDist)
				{
					exitDist = Vector2.Distance (this.gameObject.transform.position, exit.transform.position);
					nearestExit = exit.gameObject;
				}
			}

			mLookTarget = nearestExit;
			LookAtTarget();

		}
		
	}
}
