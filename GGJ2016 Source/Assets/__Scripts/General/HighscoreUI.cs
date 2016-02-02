using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighscoreUI : MonoBehaviour{

	public Text[] nameLabels;
	public Text[] scoreLabels;

	public GameObject highscoreInputPanel;
	public Text highscoreNameInput;
	public Text highscoreScoreLabel;

	HighscoreManager highscoreManager;

	int playerScore = 0;
	void Awake() {
		highscoreManager = HighscoreManager.getInstance();
		//highscoreManager.LoadFakeData ();
	}

	// Use this for initialization
	void Start () {
		bind ();
		playerScore = PlayerPrefs.GetInt ("RoundScore");
		if (highscoreManager.isNewHighscore (playerScore)) {
			highscoreInputPanel.SetActive(true);
			highscoreScoreLabel.text = playerScore.ToString();
		}
	}

	// Note JLI
	// count shouldn't need a ternary operator
	void bind() {
		List<HighscoreEntry> entries = highscoreManager.getEntries ();
		int count = (entries.Count > HighscoreManager.MAX_HIGH_SCORES ? HighscoreManager.MAX_HIGH_SCORES : entries.Count);
		for(int i = 0; i < count; i++) {
			HighscoreEntry entry = entries[i];
			//Debug.Log(entry.GetName() + "  " + entry.GetScore().ToString());
			nameLabels[i].text = entry.GetName();
			scoreLabels[i].text = entry.GetScore().ToString();
		}
	}

	public void onMainMenuClick() {
		//TODO might need to change this.
		Application.LoadLevel(0);
	}
	
	public void onNewScoreDialogClose() {
		highscoreManager.insertHighscore(highscoreNameInput.text.ToUpper(), playerScore);
		highscoreInputPanel.SetActive (false);
		bind();
	}

}
