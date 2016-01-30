using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaBullSpawner : MonoBehaviour 
{
	public List<BullExit> mBullExits = new List<BullExit>();
	[SerializeField] public GameObject mBull;
	public float mDefaultBullSpawnTime = 10f;
	float mBullSpawnTimer = 10f;

	// Use this for initialization
	void Start () 
	{
		mBullSpawnTimer = mDefaultBullSpawnTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		mBullSpawnTimer -= Time.deltaTime;

		if(mBullSpawnTimer <= 0f)
		{
			SpawnBull();
			mBullSpawnTimer = mDefaultBullSpawnTime * (Random.value+0.5f);
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
		}
	}
}
