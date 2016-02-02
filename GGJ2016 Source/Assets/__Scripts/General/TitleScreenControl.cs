using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenControl : MonoBehaviour 
{
	[SerializeField] private Text mStartText;

	float mFlickerTimer = 0.5f;

	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt("RoundScore", 0);
	}
	
	// Note JLI
	// Can used coroutine instead of update()
	void Update () 
	{
		mFlickerTimer -= Time.deltaTime;
		if(mFlickerTimer <= 0f)
		{
			mStartText.enabled = !mStartText.enabled;
			mFlickerTimer = 0.5f;
		}

		if(Input.GetAxis("Submit") != 0f || Input.GetAxis("Start") != 0f)
		{
			Application.LoadLevel(1);
		}
	}
}
