using UnityEngine;
using System.Collections;

public class BabyGenUpdate : MonoBehaviour {

	public int GenerateDelay=0,DefaultDelay=10;
	public GameObject BabyLaunch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GenerateDelay>0)
		{GenerateDelay--;}
		if (GenerateDelay==0)
		{
			Instantiate(BabyLaunch, transform.position, Quaternion.identity);
			GenerateDelay=DefaultDelay;
		}
	}
}
