using UnityEngine;
using System.Collections;

public class BullExit : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.GetComponent<ArenaBull>()!=null)
		{
			if(other.GetComponent<ArenaBull>().mExitTimer<=0f)
			{
				Destroy(other.gameObject);
				FindObjectOfType<ArenaBullSpawner>().CloseGates();
			}
		}
	}
}
