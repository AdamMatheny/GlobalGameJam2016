using UnityEngine;
using System.Collections;

public class TomatoProjectile : MonoBehaviour 
{

	[SerializeField] private float mSpeed= 5f;


	// Update is called once per frame
	void Update () 
	{
		transform.Translate (0f,Time.deltaTime*mSpeed,0f);
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if(coll.gameObject.GetComponent<ArenaPlayer>()!=null)
		{
			Debug.Log("Hit the player!");
		}
		Destroy (this.gameObject);
		
	}
}
