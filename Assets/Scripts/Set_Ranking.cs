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
        Ranking_Checker rankData = new Ranking_Checker("HighScore5", "Namest5", "HighScore4", "Namest4", "HighScore3", "Namest3", "HighScore2", "Namest2", "HighScore1", "Namest1", ScoreNo5, ScoreNo4, ScoreNo3, ScoreNo2, ScoreNo1);
        Rank_Checker(rankData);
    }
    public void Rank_Checker(Ranking_Checker ranking)
    {
        if (UpToFive(ranking.rankScore5)){Update_Ranking(ranking.rankScore4, ranking.rankName4, ranking.rankScore5, ranking.rankName5, "", "", ranking.scoreLock5);
            if (UpToFour(ranking.rankScore4)){Update_Ranking(ranking.rankScore3, ranking.rankName3,ranking.rankScore4,ranking.rankName4,ranking.rankScore5,ranking.rankName5,ranking.scoreLock4);
                    if (UpToThree(ranking.rankScore3)){Update_Ranking(ranking.rankScore2,ranking.rankName2,ranking.rankScore3,ranking.rankName3,ranking.rankScore4,ranking.rankName4,ranking.scoreLock3);
                            if (UpToTwo(ranking.rankScore2)){Update_Ranking(ranking.rankScore1,ranking.rankName1,ranking.rankScore2,ranking.rankName2,ranking.rankScore3,ranking.rankName3,ranking.scoreLock2);
                                   if (UpToOne(ranking.rankScore1)) { Update_Ranking("", "",ranking.rankScore1,ranking.rankName1,ranking.rankScore2,ranking.rankName2,ranking.scoreLock1); }}}}}
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
