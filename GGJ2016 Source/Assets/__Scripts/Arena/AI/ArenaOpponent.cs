using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaOpponent : MonoBehaviour 
{
	public ArenaPlayer mTargetPlayer;
	public int mAmmoRemaining = 3;
	[SerializeField] private GameObject mProjectile;
	[SerializeField] private GameObject mAmmoDrop;

	float mMoveSpeed = 5f;
	List<TomatoStand> mTomatoStands = new List<TomatoStand>();

	enum AIState {ATTACKING, RELOADING};

	AIState mAIState = AIState.ATTACKING;

	float mAttackTimer = 3f;
	float mMoveTimer = 3f;

	Vector3 mTargetPos = Vector3.zero;
	[SerializeField] private float[] mBounds;

	// Use this for initialization
	void Start () 
	{
		SetMoveTarget();
	}//END of Start()
	
	// Update is called once per frame
	void Update () 
	{
		mAttackTimer -= Time.deltaTime;
		mMoveTimer -= Time.deltaTime;

		if(mAttackTimer <= 0f && mAIState == AIState.ATTACKING)
		{
			ThrowTomato();
		}

		if(mMoveTimer <= 0f && mAIState == AIState.ATTACKING)
		{
			SetMoveTarget();
		}

	}//END of Update

	void LookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation
			(mTargetPlayer.gameObject.transform.position - transform.position, transform.TransformDirection(Vector3.up));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	}

	void MoveToTarget()
	{

	}

	void SetMoveTarget()
	{

		mMoveTimer = 3f;
	}

	void ThrowTomato()
	{

		mAmmoRemaining--;

		mAttackTimer = 3f;
	}
}