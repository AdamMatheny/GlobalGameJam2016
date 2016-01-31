using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaBullSpawner : MonoBehaviour 
{
	public List<BullExit> mBullExits = new List<BullExit>();
	[SerializeField] public GameObject mBull;
	public float mDefaultGateOpenTime = 20f;
	float mBullSpawnTimer = 0.5f;
	[SerializeField] public float mGateOpenTimer = 20;

	bool mGatesOpen = false;

	int mActiveBulls = 0;

	//For how many bulls to spawn per round ~Adam
	public int mDefaultBullCount = 5;
	int mBullCount = 0;

	//Pickups to spawn when bull wave is over ~ADam
	public GameObject mHealthPickup;
	public GameObject mAmmoPickup;

	// Use this for initialization
	void Start () 
	{
		//Uncomment this to make waves more frequent as rounds go on ~Adam
//		mDefaultGateOpenTime -= PlayerPrefs.GetInt("ArenaRound");
//		if(mDefaultGateOpenTime <5f)
//		{
//			mDefaultGateOpenTime = 5f;
//		}

		mGateOpenTimer = mDefaultGateOpenTime+5f;
		mDefaultBullCount += PlayerPrefs.GetInt("ArenaRound");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		mGateOpenTimer -= Time.deltaTime;

		if(mGateOpenTimer <= 5f && mGateOpenTimer>0f)
		{
			mBullSpawnTimer -= Time.deltaTime;
			mGatesOpen = true;

		}

		if(mBullSpawnTimer <= 0f)
		{
			if(mBullCount < mDefaultBullCount)
			{
				SpawnBull();
				mBullCount++;
			}
			mBullSpawnTimer = 0.5f-(PlayerPrefs.GetInt("ArenaRound")*0.05f);
			if(mBullSpawnTimer<=0.15f)
			{
				mBullSpawnTimer = 0.15f;
			}
		}

        if (mGateOpenTimer <= 7f && mGateOpenTimer >= 4.5f)
		{
			Camera.main.GetComponent<CameraShake>().ShakeCamera();
		}
	}

	void SpawnBull()
	{
		GameObject spawnGate = null;
		if(mBullExits.Count >0)
		{
			spawnGate = mBullExits[Mathf.FloorToInt( Random.Range(0,mBullExits.Count))].gameObject;
		}

		if(spawnGate !=null)
		{
			Instantiate(mBull,spawnGate.transform.position,Quaternion.identity);
			mActiveBulls++;
		}
	}

	public void CloseGates()
	{
		mActiveBulls--;
		if(mActiveBulls<=0)
		{
			mActiveBulls = 0;
			mGatesOpen = false;
			mGateOpenTimer = mDefaultGateOpenTime+5f;
			if(FindObjectOfType<ArenaPlayer>().health <4)
			{
				Instantiate(mHealthPickup, Random.insideUnitCircle*4f, Quaternion.identity);
			}
			else
			{
				Instantiate(mAmmoPickup, Random.insideUnitCircle*4f, Quaternion.identity);
			}
			mBullCount = 0;
			mDefaultBullCount++;
		}
	}
}
