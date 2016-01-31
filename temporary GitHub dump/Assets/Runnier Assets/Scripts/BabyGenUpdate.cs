using UnityEngine;
using System.Collections;

public class BabyGenUpdate : MonoBehaviour {

	public int GenerateDelay=0,DefaultDelay=10;
	public GameObject[] BabyLaunch=new GameObject[6];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int BType=Random.Range(0, 6); 

		if (GenerateDelay>0)
		{GenerateDelay--;}
		if (GenerateDelay==0)
		{
			Instantiate(BabyLaunch[BType], transform.position, Quaternion.identity);
			GenerateDelay=DefaultDelay-Random.Range(0, 40);
		}
	}
}
