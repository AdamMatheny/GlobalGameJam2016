using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HighscoreManager {

	const string PLAYER_PREF_HIGHSCORE_KEY = "highscore_key";
	const int MAX_HIGH_SCORES = 10;
	private List<HighscoreEntry> mEntries;
	private HighscoreManager sInstance = null;

	public HighscoreManager getInstance() {
		if (sInstance == null) {
			sInstance = new HighscoreManager ();
		}
		return sInstance;
	}

	private HighscoreManager() {
		mEntries = new List<HighscoreEntry> ();
		Load ();	
	}

	public void addScore(HighscoreEntry entry) {
		mEntries.Add(entry);
	}

	public void Load() {
		mEntries.Clear();
		string serializedScores = PlayerPrefs.GetString (PLAYER_PREF_HIGHSCORE_KEY, "");
		if (serializedScores.Length == 0)
			return;
		IList json = (IList) MiniJSON.Json.Deserialize(serializedScores);
		foreach (IDictionary entry in json) {
			String name = entry ["name"].ToString ();
			int score = Convert.ToInt32(entry ["score"]);
			HighscoreEntry newEntry = new HighscoreEntry (name, score);
			mEntries.Add (newEntry);
		}	
		mEntries.Sort ();
		int entryCount = mEntries.Count;
		mEntries.RemoveRange (MAX_HIGH_SCORES, entryCount - MAX_HIGH_SCORES);
	}

	public void Save() {
		mEntries.Sort();

		List<Dictionary<string, System.Object>> data = new List<Dictionary<string, System.Object>>();
		int count = mEntries.Count;
		for (int i = 0; i < count; i++) {
			data.Add(mEntries[i].asDictionary());
		}

		string payload = MiniJSON.Json.Serialize(data);
		PlayerPrefs.SetString (PLAYER_PREF_HIGHSCORE_KEY, payload);
		PlayerPrefs.Save ();
		//Debug.Log("Highscore data: " + payload);
	}

	//See the logs
	public void Test() {
		HighscoreEntry a = new HighscoreEntry ("Janna", 230);
		HighscoreEntry b = new HighscoreEntry ("Mac", 100);
		HighscoreEntry c = new HighscoreEntry ("Doug", 80);
		mEntries = new List<HighscoreEntry>(){a,b,c};
		Save ();
		mEntries.Clear ();
		Load();
		Debug.Log (mEntries.Count);
		for (int i = 0; i < mEntries.Count; i++) {
			Debug.Log ("Score: " + mEntries[i].GetName() + " " + mEntries[i].GetScore());
		}
	}
}
