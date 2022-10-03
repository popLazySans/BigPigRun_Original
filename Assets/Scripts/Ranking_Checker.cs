using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking_Checker : MonoBehaviour
{
    public string rankScore5;
    public string rankName5;
    public string rankScore4;
    public string rankName4;
    public string rankScore3;
    public string rankName3;
    public string rankScore2;
    public string rankName2;
    public string rankScore1;
    public string rankName1;
    public int scoreLock5;
    public int scoreLock4;
    public int scoreLock3;
    public int scoreLock2;
    public int scoreLock1;

    public Ranking_Checker(string rankScore5, string rankName5, string rankScore4, string rankName4, string rankScore3, string rankName3, string rankScore2, string rankName2, string rankScore1, string rankName1, int scoreLock5, int scoreLock4, int scoreLock3, int scoreLock2, int scoreLock1)
    {
        this.rankScore5 = rankScore5;
        this.rankName5 = rankName5;
        this.rankScore4 = rankScore4;
        this.rankName4 = rankName4;
        this.rankScore3 = rankScore3;
        this.rankName3 = rankName3;
        this.rankScore2 = rankScore2;
        this.rankName2 = rankName2;
        this.rankScore1 = rankScore1;
        this.rankName1 = rankName1;
        this.scoreLock5 = scoreLock5;
        this.scoreLock4 = scoreLock4;
        this.scoreLock3 = scoreLock3;
        this.scoreLock2 = scoreLock2;
        this.scoreLock1 = scoreLock1;
    }
}
