using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

	public Text BestScore1;
	public Text NameBestScoreNo1;
	public Text BestScore2;
	public Text NameBestScoreNo2;
	public Text BestScore3;
	public Text NameBestScoreNo3;
	public Text BestScore4;
	public Text NameBestScoreNo4;
	public Text BestScore5;
	public Text NameBestScoreNo5;
	public float score;
	// Use this for initialization
	void Start () 
	{
		BestScore();
		NameBestScore();
	}
	
	// Update is called once per frame
	void Update () {
		score = Point.score_point;
	}
	public void Reset(){
		PlayerPrefs.DeleteKey ("HighScore1");
		PlayerPrefs.DeleteKey ("Namest1");
		PlayerPrefs.DeleteKey ("HighScore2");
		PlayerPrefs.DeleteKey ("Namest2");
		PlayerPrefs.DeleteKey ("HighScore3");
		PlayerPrefs.DeleteKey ("Namest3");
		PlayerPrefs.DeleteKey ("HighScore4");
		PlayerPrefs.DeleteKey ("Namest4");
		PlayerPrefs.DeleteKey ("HighScore5");
		PlayerPrefs.DeleteKey ("Namest5");
	}

	public void BestScore() 
	{
		BestScore1.text = PlayerPrefs.GetFloat("HighScore1", 0).ToString() + " km";
		BestScore2.text = PlayerPrefs.GetFloat("HighScore2", 0).ToString() + " km";
		BestScore3.text = PlayerPrefs.GetFloat("HighScore3", 0).ToString() + " km";
		BestScore4.text = PlayerPrefs.GetFloat("HighScore4", 0).ToString() + " km";
		BestScore5.text = PlayerPrefs.GetFloat("HighScore5", 0).ToString() + " km";
	}

	public void NameBestScore() 
	{
		NameBestScoreNo1.text = PlayerPrefs.GetString("Namest1", "");
		NameBestScoreNo2.text = PlayerPrefs.GetString("Namest2", "");
		NameBestScoreNo3.text = PlayerPrefs.GetString("Namest3", "");
		NameBestScoreNo4.text = PlayerPrefs.GetString("Namest4", "");
		NameBestScoreNo5.text = PlayerPrefs.GetString("Namest5", "");
	}
}
