using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll
{
    public int Score { get; private set; }
    public FrameScoring ScoreType { get; private set; }

    public Roll(FrameScoring scoreType, int score)
    {
        Score = score;
        ScoreType = scoreType;
    }
}
