using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour 
{
	public bool mGrantHealth = false;
	public bool mGrantAmmo = true;


	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.GetComponent<ArenaPlayer>()!=null)
		{
			if(mGrantHealth)
			{
				other.GetComponent<ArenaPlayer>().health++;
				if(other.GetComponent<ArenaPlayer>().health >4)
				{
					other.GetComponent<ArenaPlayer>().health=4;
				}
			}
			if(mGrantAmmo)
			{
				other.GetComponent<ArenaPlayer>().tomatoCount+=3;
			}
			Destroy (this.gameObject);
		}
	}
}
