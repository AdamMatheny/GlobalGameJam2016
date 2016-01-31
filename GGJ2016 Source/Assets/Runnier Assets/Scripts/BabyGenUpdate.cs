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
	public float ElapsedTime=0f;
	public GameObject UIText;

	// Use this for initialization
	void Start () {
		ElapsedTime = Time.time + 1;
		//JumpPointList.ElementAt(,)

		//JumpPointList
	}
	
	// Update is called once per frame
	void Update () {
		int BType=Random.Range(0, 6); 
		float timeSec = ElapsedTime - Time.time;

		if (StartGenerating==true)
		{
			//generate a baby object once a second passes.
			if (timeSec < 0) 
			{
				ElapsedTime = Time.time + 1;
				Instantiate(BabyLaunch[BType], transform.position, Quaternion.identity);
			}
		}
		SetTomatoCountText(timeSec);


	}

	void SetTomatoCountText(float ts)
	{
		UIText.GetComponent<Text>().text = ("time: "+ts.ToString ()); //Display Health and Ammo	
	}

}
