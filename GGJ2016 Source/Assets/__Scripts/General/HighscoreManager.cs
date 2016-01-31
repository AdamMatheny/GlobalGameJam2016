using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HighscoreManager {

	const string PLAYER_PREF_HIGHSCORE_KEY = "highscore_key";
	public const int MAX_HIGH_SCORES = 10;
	private List<HighscoreEntry> mEntries;
	private static HighscoreManager sInstance = null;

	public static HighscoreManager getInstance() {
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

	public List<HighscoreEntry> getEntries() {
		return mEntries;
	}

	public void Load() {
		mEntries.Clear();
		string serializedScores = PlayerPrefs.GetString (PLAYER_PREF_HIGHSCORE_KEY, "");
		//Debug.Log ("Serialized Scores: " + serializedScores);
		if (serializedScores.Length == 0) {
			fillInEmptyEntries ();
			return;
		}
		IList json = (IList) MiniJSON.Json.Deserialize(serializedScores);
		foreach (IDictionary entry in json) {
			String name = entry ["name"].ToString ();
			int score = Convert.ToInt32(entry ["score"]);
			HighscoreEntry newEntry = new HighscoreEntry (name, score);
			mEntries.Add (newEntry);
		}	
		mEntries.Sort ();

		// If there are any empty entries ...
		fillInEmptyEntries ();
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

	protected void cropExtraEntries() {
		//Check if more than 10, skim.
		int entryCount = mEntries.Count;
		if (entryCount <= MAX_HIGH_SCORES)
			return;
		mEntries.RemoveRange (MAX_HIGH_SCORES, Mathf.Abs(entryCount - MAX_HIGH_SCORES));
	}

	public void fillInEmptyEntries() {
		int emptyEntriesNeeded = Mathf.Abs(mEntries.Count - MAX_HIGH_SCORES);
		for(int i = 0; i < emptyEntriesNeeded; i++) {
			HighscoreEntry entry = new HighscoreEntry("AAA", 0);
			mEntries.Add(entry);
		}
		mEntries.Sort();
	}

	public bool isNewHighscore(int score) {
		if (score > mEntries [mEntries.Count - 1].GetScore ()) {
			return true;
		}
		return false;
	}


	public int getScoreRank(int score)
	{
		int scoreCount = mEntries.Count;
		for (int i = 0; i < scoreCount; i++) {
			if(score > mEntries[i].GetScore()){
				return i;
			}
		}
		return -1;
	}

	public void insertHighscore(String name, int score) {
		mEntries.Add (new HighscoreEntry (name, score));
		PrintLogEntries ();
		mEntries.Sort();
		PrintLogEntries ();
		cropExtraEntries ();
	}

	/// <summary>
	/// TEST FUNCTIONS BELOW
	/// </summary>


	public void PrintLogEntries() { 
		for (int i = 0; i < mEntries.Count; i++) {
			HighscoreEntry entry = mEntries[i];
			Debug.Log("Score " + i.ToString() + " : " + entry.GetName() + " " + entry.GetScore().ToString());
		}
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

	public void LoadFakeData() {
		HighscoreEntry a = new HighscoreEntry ("DAG", 3210);
		HighscoreEntry b = new HighscoreEntry ("JON", 2800);
		HighscoreEntry c = new HighscoreEntry ("NIC", 2750);
		HighscoreEntry d = new HighscoreEntry ("DAV", 2100);
		HighscoreEntry e = new HighscoreEntry ("ADM", 1800);
		HighscoreEntry f = new HighscoreEntry ("ADM", 1670);
		HighscoreEntry g = new HighscoreEntry ("ADM", 1670);
		HighscoreEntry h = new HighscoreEntry ("ADM", 1670);
		HighscoreEntry i = new HighscoreEntry ("ADM", 1670);
		HighscoreEntry j = new HighscoreEntry ("ADM", 1670);
		mEntries = new List<HighscoreEntry>(){a,b,c,d,e,f,g,h,i,j};
	}
}
