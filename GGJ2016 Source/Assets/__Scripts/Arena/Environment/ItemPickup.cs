using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour 
{
	public bool mGrantHealth = false;
	public bool mGrantAmmo = true;
	[SerializeField] private int mHealthAmount = 1;
	[SerializeField] private int mAmmoAmount = 1;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.GetComponent<ArenaPlayer>()!=null)
		{
			if(mGrantHealth)
			{
				other.GetComponent<ArenaPlayer>().health+=mHealthAmount;
				if(other.GetComponent<ArenaPlayer>().health >4)
				{
					other.GetComponent<ArenaPlayer>().health=4;
				}
			}
			if(mGrantAmmo)
			{
				other.GetComponent<ArenaPlayer>().tomatoCount+=mAmmoAmount;
			}
			Destroy (this.gameObject);
		}
	}
}
