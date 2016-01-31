using UnityEngine;
using System.Collections;

public class ArenaPlayerGraphics : MonoBehaviour 
{
	public Transform mPlayerTransform;
	public Transform mCrossHairsTransform;

	Vector3 mRightScale = new Vector3(3f,3f,1f);
	Vector3 mLeftScale = new Vector3(-3f,3f,1f);
	bool mMoving = false;

	public Animator mAnimator;

	// Update is called once per frame
	void Update () 
	{
		if(mPlayerTransform != null)
		{
			transform.position = mPlayerTransform.position;

			if(mCrossHairsTransform !=null)
			{
				if(mCrossHairsTransform.position.x > mPlayerTransform.position.x)
				{
					transform.localScale = mRightScale;
				}
				else if(mCrossHairsTransform.position.x < mPlayerTransform.position.x)
				{
					transform.localScale = mLeftScale;
				}
			}
		}

		mMoving = (Input.GetAxis("AnalogLeftHorizontal") != 0 || Input.GetAxis("AnalogLeftVertical") != 0);
		mAnimator.SetBool("Moving", mMoving);
		
	}

	public void mPlayThrowAnim()
	{
		bool mThrowUp = (mCrossHairsTransform.position.y >= mPlayerTransform.position.y);

		if(mMoving)
		{
			if(mThrowUp)
			{
				mAnimator.Play ("ArenaRightRunThrowUp");
			}
			else
			{
				mAnimator.Play ("ArenaRightRunThrowDown");
			}
		}
		else
		{
			if(mThrowUp)
			{
				mAnimator.Play ("ArenaIdleThrowUp");
			}
			else
			{
				mAnimator.Play ("ArenaIdleThrowDown");
			}
		}

	}
}
