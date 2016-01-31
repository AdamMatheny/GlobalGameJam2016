using System;
using System.Collections.Generic;

public class HighscoreEntry : IComparable
{
	private string mName;
	private int mScore;
	public HighscoreEntry (String name, int score)
	{
		mName = name;
		mScore = score;
	}

	public string GetName() { return mName; } 
	public int GetScore() {
		return mScore;
	}

	public Dictionary<String, System.Object> asDictionary() {
		Dictionary<String, System.Object> entry = new Dictionary<String, System.Object> ();
		entry["name"] = GetName();
		entry["score"] = GetScore();
		return entry;
	}

	//Used by sort
	int IComparable.CompareTo(object obj)
	{
		HighscoreEntry entry=(HighscoreEntry)obj;
		return entry.GetScore () - this.GetScore ();
	}
}

