using UnityEngine;
using System.Collections;


public class CameraShake : MonoBehaviour 
{

	float mStrength = 2.5f;
	float mShakeTime = 0f;

	public float mShakeStrength = 2.5f;
	public float mShakeDuration = 0.25f;

	Vector3 mStartingPosition;
	// Use this for initialization
	void Start () 
	{
		mStartingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		
		if (mShakeTime > 0 && Time.timeScale != 0f)
		{
			transform.position = mStartingPosition+(Random.insideUnitSphere * mStrength);
			mShakeTime -= Time.deltaTime;
		}
		else
		{
			mShakeTime = 0f;
			transform.position = mStartingPosition;
		}
	}
	

	
	public void ShakeCamera()
	{
		mStrength = mShakeStrength;
		mShakeTime = mShakeDuration;
	}

}
