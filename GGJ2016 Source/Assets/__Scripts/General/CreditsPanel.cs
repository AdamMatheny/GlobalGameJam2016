using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsPanel : MonoBehaviour 
{
	
	public float mCreditsTimer = 30f;
	public float mScrollSpeed = 0.1f;
	public Image mBlackFade;


	void Update () 
	{
		mCreditsTimer -= Time.deltaTime;
		if(mCreditsTimer <= 2f)
		{
			mBlackFade.color = Color.Lerp(mBlackFade.color, Color.black, Time.deltaTime);
		}
		if(mCreditsTimer<=0f)
		{
			Application.LoadLevel(0);
		}
		transform.position += Vector3.left*mScrollSpeed;

	}
}
