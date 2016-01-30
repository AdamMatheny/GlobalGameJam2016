using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaOpponent : MonoBehaviour 
{
	public ArenaPlayer mTargetPlayer;
	public int mAmmoRemaining = 3;
	[SerializeField] private GameObject mProjectile;
	[SerializeField] private GameObject mAmmoDrop;

	[SerializeField] private float mMoveSpeed = 5f;

	//Spots to reload at ~Adam
	[SerializeField] private List<TomatoStand> mTomatoStands = new List<TomatoStand>();

	//Whether the opponent is trying to attack or go back for more ammo ~Adam
	enum AIState {ATTACKING, RELOADING};
	[SerializeField] private AIState mAIState = AIState.ATTACKING;

	//Timers for moving and attacking ~Adam
	[SerializeField] private float mDefaultAttackTime = 3f;
	float mAttackTimer = 3f;
	[SerializeField] private float mDefaultMoveTime = 4f;
	float mMoveTimer = 3f;

	//Where to move to ~Adam
	Vector3 mTargetPos = Vector3.zero;
	[SerializeField] private float mArenaRadius = 5.5f;

	GameObject mLookTarget;

	// Use this for initialization
	void Start () 
	{
		if(mTargetPlayer == null)
		{
			mTargetPlayer = FindObjectOfType<ArenaPlayer>();
		}
		mLookTarget = mTargetPlayer.gameObject;
		SetMoveTarget();
		mTomatoStands = FindObjectOfType<StandManager>().mTomatoStands;
	}//END of Start()
	
	// Update is called once per frame
	void Update () 
	{
		//Change AI state based on ammo count ~Adam
		if(mAmmoRemaining > 0)
		{
			mAIState = AIState.ATTACKING;
		}
		else
		{
			mAIState = AIState.RELOADING;
		}

		//If attacking, move around and throw tomatos
		if(mAIState == AIState.ATTACKING)
		{
			mLookTarget = mTargetPlayer.gameObject;
			mAttackTimer -= Time.deltaTime;
			mMoveTimer -= Time.deltaTime;

			if(mAttackTimer <= 0f)
			{
				ThrowTomato();
			}
			
			if(mMoveTimer <= 0f || Vector2.Distance (transform.position,mTargetPos) <= 1f)
			{
				SetMoveTarget();
			}
		}

		else if (mAIState == AIState.RELOADING)
		{
			FindNearestStand();
		}

		MoveToTarget();
		LookAtTarget();





	}//END of Update

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


	void MoveToTarget()
	{
		transform.position = Vector2.Lerp(transform.position, mTargetPos, 0.005f*mMoveSpeed);
	}

	void SetMoveTarget()
	{
		mTargetPos = Random.insideUnitCircle * mArenaRadius;

		mMoveTimer = mDefaultMoveTime * (Random.value+0.5f);
	}

	void ThrowTomato()
	{
		//Instantiate a tomato moving in the dirction the opponent is facing ~Adam
		Instantiate(mProjectile, transform.position+transform.up, transform.rotation);
		//Decrement ammo.  If it's now out of ammo, find the nearest tomato stand and start going to it.
		mAmmoRemaining--;
	

		mAttackTimer = mDefaultAttackTime * (Random.value+0.5f);
	}

	void FindNearestStand()
	{
		if(mTomatoStands.Count > 0)
		{
			float standRange = 1000f;
			GameObject targetStand = null;
			foreach(TomatoStand stand in mTomatoStands)
			{
				if(Vector2.Distance(this.gameObject.transform.position, stand.gameObject.transform.position) <= standRange)
				{
					standRange = Vector2.Distance(this.gameObject.transform.position, stand.gameObject.transform.position);
					targetStand = stand.gameObject;
				}
			}
			if(targetStand != null)
			{
				mTargetPos = targetStand.transform.position;
				mLookTarget = targetStand;
			}
		}
	}

	void GetHitByPlayer()
	{

	}
}