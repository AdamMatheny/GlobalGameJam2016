using UnityEngine;
using System.Collections;

public class GroundGenUpdate : MonoBehaviour {
	
	public int GenerateDelay=0,DefaultDelay=10;
	public GameObject[] GroundLaunch=new GameObject[2];
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int BType=Random.Range(0, 3); 
		
		if (GenerateDelay>0)
		{GenerateDelay--;}
		if (GenerateDelay==0)
		{

            Debug.Log("Created it");

			Instantiate(GroundLaunch[BType], transform.position, Quaternion.identity);

			GenerateDelay=DefaultDelay;
		}
	}
}

