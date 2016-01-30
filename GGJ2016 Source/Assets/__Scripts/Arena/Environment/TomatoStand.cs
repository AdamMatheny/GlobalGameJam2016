using UnityEngine;
using System.Collections;

public class TomatoStand : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.GetComponent<ArenaOpponent>()!=null)
		{
			other.GetComponent<ArenaOpponent>().mAmmoRemaining = 3;
		}
	}
}
