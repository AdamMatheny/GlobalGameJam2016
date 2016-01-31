using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class BabyGenUpdate : MonoBehaviour 
{

	public int GenerateDelay=0, DefaultDelay=60;
	public bool StartGenerating=false;
	public GameObject[] BabyLaunch=new GameObject[6];

	public GameObject UIText;


	#region These didn't seem to be doing anything anymore ~Adam
	public float ElapsedTime = 0f;
	public float TotalTime = 0f;
	public float SecondBGMTotalTime = 0f;
	#endregion

	#region For spawning babies based on Tempo ~Adam

	//Array of the points in time at which the tempo should change ~Adam
	public float[] mTempoChangePoint;
	//Array of the parameters to pass to mTempoValues for finding the current baby spawning tempo ~Adam
	public int[] mTempoChangeParams; 

	//Array of possibly intervals in seconds (with decimals) on how often to spawn babies ~Adam
	public float[] mTempoValues=new float[4];
	// Use this for initialization

	//Timer for baby spawning ~Adam
	public float mBabySpawnTimer = 0f;
	//Timer for changing the tempo ~Adam
	public float mTempoTimer = 0f;

	//Which spot in mTempoValues we're looking at to decide tempo ~Adam
	public int mTempoSetting = 0;
	//Which spot in mTempoChangePoints we're on ~Adam
	public int mTempoPoint = 0;
	//Chance to actually spawn a baby when the timer is up ~Adam
	public float mBabySpawnChance = 0.25f;
	//Bool to prevent spawnign two babies next to eachother ~Adam
	public bool mJustSpawned = false;
	#endregion

	void Start () 
	{
		//tells us when a second passes.
		ElapsedTime = Time.time + 1;
		//tells us the total time passed sinc ethe intro BGM finished.
		TotalTime = Time.time;
		//tells us how much time passes since the second BGM started
		SecondBGMTotalTime = Time.time;
		//JumpPointList.ElementAt(,)

		//JumpPointList
	}
	
	// Update is called once per frame
	void Update () 
	{
		int BType=Random.Range(0, 6); 
		//get the time passed since the last second.
		float timeSec = ElapsedTime - Time.time;
		//get the amount of passed since the last second in an integer, a percentage of a second.
		int timePercent=(int)(timeSec*100);
		//get the total amount of time passed in seconds since the intro BGM finished.
		float totalTimePassed=TotalTime - Time.time;

		if (StartGenerating==true)
		{
			//Increment the tempo and spawn timers ~Adam
			mTempoTimer += Time.deltaTime;
			mBabySpawnTimer += Time.deltaTime;

			//Make spawn chance go up over time, but have a cap  ~Adam
			if(mBabySpawnChance <= 0.8f)
			{
				mBabySpawnChance += Time.deltaTime*0.1f;
			}

			//Change the tempo at the set points in time ~Adam
			if(mTempoTimer > mTempoChangePoint[mTempoPoint])
			{
				mTempoSetting = mTempoChangeParams[mTempoPoint];
				mTempoPoint++;
				//Loop back to the start of the tempo timing ~Adam
				if(mTempoPoint >= mTempoChangePoint.Length)
				{
					mTempoPoint = 0;
					mTempoTimer = 0f;
				}
			}

			//Spawn babies to the tempo ~Adam
			if (mBabySpawnTimer > mTempoValues[mTempoSetting]) 
			{
				//Have a random chane of spawning on the tempo beat ~Adam
				if(Random.value < mBabySpawnChance)
				{
					//Make sure we don't spawn twice in a row ~Adam
					if(!mJustSpawned)
					{
						Instantiate(BabyLaunch[BType], transform.position, Quaternion.identity);
					}
					mJustSpawned = !mJustSpawned;
				}
				mBabySpawnTimer = 0f;
			}
		}
		SetTomatoCountText(totalTimePassed);


	}

	void SetTomatoCountText(float ts)
	{
		UIText.GetComponent<Text>().text = ("time: "+ts.ToString ()); //Display Health and Ammo	
	}

}
