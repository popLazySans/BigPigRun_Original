using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Ranking : MonoBehaviour
{
    public int ScoreNo1;
    public int ScoreNo2;
    public int ScoreNo3;
    public int ScoreNo4;
    public int ScoreNo5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HightScore_Current();
    }
    public void HightScore_Current()
    {
        Rank_Checker("HighScore5", "Namest5", "HighScore4", "Namest4", "HighScore3", "Namest3", "HighScore2", "Namest2", "HighScore1", "Namest1", ScoreNo5, ScoreNo4, ScoreNo3, ScoreNo2, ScoreNo1);
    }
    public void Rank_Checker(string rankScore5, string rankName5, string rankScore4, string rankName4, string rankScore3, string rankName3, string rankScore2, string rankName2, string rankScore1, string rankName1, int scoreLock5, int scoreLock4, int scoreLock3, int scoreLock2, int scoreLock1)
    {
        if (UpToFive(rankScore5)){Update_Ranking(rankScore4, rankName4, rankScore5, rankName5, "", "", scoreLock5);
            if (UpToFour(rankScore4)){Update_Ranking(rankScore3, rankName3, rankScore4, rankName4, rankScore5, rankName5, scoreLock4);
                    if (UpToThree(rankScore3)){Update_Ranking(rankScore2, rankName2, rankScore3, rankName3, rankScore4, rankName4, scoreLock3);
                            if (UpToTwo(rankScore2)){Update_Ranking(rankScore1, rankName1, rankScore2, rankName2, rankScore3, rankName3, scoreLock2);
                                   if (UpToOne(rankScore1)) { Update_Ranking("", "", rankScore1, rankName1, rankScore2, rankName2, scoreLock1); }}}}}
    }
    public bool UpToFive(string rankScore5){return Point.score_point > PlayerPrefs.GetFloat(rankScore5, 0);}
    public bool UpToFour(string rankScore4) { return Point.score_point > PlayerPrefs.GetFloat(rankScore4, 0);}
    public bool UpToThree(string rankScore3) { return Point.score_point > PlayerPrefs.GetFloat(rankScore3, 0); }
    public bool UpToTwo(string rankScore2) { return Point.score_point > PlayerPrefs.GetFloat(rankScore2, 0); }
    public bool UpToOne(string rankScore1) { return Point.score_point > PlayerPrefs.GetFloat(rankScore1, 0); }
    public void Update_Ranking(string rankScorePlus, string rankNamePlus, string rankScore, string rankName, string rankScoreDe, string rankNameDe, int scoreLock)
    {
        if (scoreLock == 0) { if (rankScoreDe != "") { reset_HighScore(rankScoreDe, rankNameDe, rankScore, rankName); } scoreLock = 1; }
        if (rankScorePlus == "" || (Point.score_point > PlayerPrefs.GetFloat(rankScore, 0) && Point.score_point < PlayerPrefs.GetFloat(rankScorePlus, 0))) { set_HighScore(rankScore, rankName); }
    }
    public void reset_HighScore(string rankScoreDe, string rankNameDe, string rankScore, string rankName)
    {
        PlayerPrefs.SetFloat(rankScoreDe, PlayerPrefs.GetFloat(rankScore, 0));
        PlayerPrefs.SetString(rankNameDe, PlayerPrefs.GetString(rankName, ""));
    }
    public void set_HighScore(string rankScore, string rankName)
    {
        PlayerPrefs.SetFloat(rankScore, Point.score_point);
        PlayerPrefs.SetString(rankName, name);
    }
}
