﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class RunnerAudioManager : MonoBehaviour {

	// Use this for initialization	
	public AudioClip[] otherClip=new AudioClip[2];
	AudioSource audio;
	public int mTrackNumber=0;
	public GameObject BG;
	BabyGenUpdate BGU;

	// Play default sound
	void Start()
	{
		audio = GetComponent<AudioSource>();
		audio.Play();
		/*
		// Wait for the audio to have finished
		yield return new WaitForSeconds(audio.clip.length);
		
		// Assign the other clip and play it
		audio.clip = otherClip[0];
		audio.Play();
		*/
	}
	
	// Update is called once per frame
	void Update () {

		//check the track which needs to be played.
		if (!audio.isPlaying)
		{
			// Begin the switch.
			switch (mTrackNumber)
			{
				case 0:
						audio.clip = otherClip[0];
						audio.Play(); 
						mTrackNumber=1;
						BGU=BG.GetComponent<BabyGenUpdate>();
					//start generating babies and counting time.
						BGU.StartGenerating=true;
						BGU.ElapsedTime=Time.time + 1;
						BGU.TotalTime = Time.time;
					break;
				case 1:
						audio.clip = otherClip[1];
						audio.Play();
					//start counting down on a second timer.
						BGU.SecondBGMTotalTime = Time.time;
					break;
			}
		}
		//END check the track which needs to be played.

	}

}
