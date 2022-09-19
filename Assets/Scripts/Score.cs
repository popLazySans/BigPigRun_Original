using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

	public Text best1;
	public Text namest1;
	public Text best2;
	public Text namest2;
	public Text best3;
	public Text namest3;
	public Text best4;
	public Text namest4;
	public Text best5;
	public Text namest5;
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
		best1.text = PlayerPrefs.GetFloat("HighScore1", 0).ToString() + " km";
		best2.text = PlayerPrefs.GetFloat("HighScore2", 0).ToString() + " km";
		best3.text = PlayerPrefs.GetFloat("HighScore3", 0).ToString() + " km";
		best4.text = PlayerPrefs.GetFloat("HighScore4", 0).ToString() + " km";
		best5.text = PlayerPrefs.GetFloat("HighScore5", 0).ToString() + " km";
	}

	public void NameBestScore() 
	{
		namest1.text = PlayerPrefs.GetString("Namest1", "");
		namest2.text = PlayerPrefs.GetString("Namest2", "");
		namest3.text = PlayerPrefs.GetString("Namest3", "");
		namest4.text = PlayerPrefs.GetString("Namest4", "");
		namest5.text = PlayerPrefs.GetString("Namest5", "");
	}
}
