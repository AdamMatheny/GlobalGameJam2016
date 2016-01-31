using UnityEngine;
using System.Collections;

public class BuildingGenUpdate : MonoBehaviour {
	
	public int GenerateDelay=0,DefaultDelay=10;
	public GameObject[] BuildingLaunch=new GameObject[2];
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int BType=Random.Range(0, 5); 

		if (GenerateDelay>0)
		{GenerateDelay--;}
		if (GenerateDelay==0)
		{
			if (BType==0 || BType==1 || BType==2)
			{Instantiate(BuildingLaunch[BType], transform.position, Quaternion.identity);}
			if (BType==3 || BType==4)
			{Instantiate(BuildingLaunch[BType], transform.position+Vector3.down, Quaternion.identity);}

			GenerateDelay=DefaultDelay-Random.Range(0, 40);
		}
	}
}
