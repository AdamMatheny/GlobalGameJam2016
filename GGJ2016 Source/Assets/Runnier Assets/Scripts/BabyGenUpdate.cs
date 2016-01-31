using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class BabyGenUpdate : MonoBehaviour {

	public int GenerateDelay=0, DefaultDelay=60;
	public bool StartGenerating=false;
	public GameObject[] BabyLaunch=new GameObject[6];
	public float endTime=0f;
	public float ElapsedTime=0f, TotalTime=0f,SecondBGMTotalTime=0f;
	public GameObject UIText;
	/*
	 * These are the points in time, which are represented in seconds once the intro BGM is done, that
	 * can change the below values.
	 *These values determine at what point in the song the baby generation tempo can change.
	*/
	public int[] TempoChangePoint=new int[10];
	/*
	 *These are the values, represented by the amount of time in a percentage of a second, which
	 *the game can look at and see whether or not to generate a baby. 
	 *These values determines how often babies can appear.
	 */
	public int[] TempoValues=new int[4];
	
	// Use this for initialization
	void Start () {
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
	void Update () {
		int BType=Random.Range(0, 6); 
		//get the time passed since the last second.
		float timeSec = ElapsedTime - Time.time;
		//get the amount of passed since the last second in an integer, a percentage of a second.
		int timePercent=(int)(timeSec*100);
		//get the total amount of time passed in seconds since the intro BGM finished.
		float totalTimePassed=TotalTime - Time.time;

		if (StartGenerating==true)
		{
			//generate a baby object once every second.
			if (timePercent==0) 
			{
				ElapsedTime = Time.time + 1;
				Instantiate(BabyLaunch[BType], transform.position, Quaternion.identity);
			}
		}
		//SetTomatoCountText(totalTimePassed);
	}

	void SetTomatoCountText(float ts)
	{
		UIText.GetComponent<Text>().text = ("time: "+ts.ToString ()); //Display Health and Ammo	
	}

}
