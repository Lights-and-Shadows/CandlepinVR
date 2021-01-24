using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Player
{
    public Frame[] Frames { get; private set; }
    public int TotalScore { get { return Frames.Sum(frame => frame.TotalScore); } }

    private int currentFrame;
    private int remainingRolls;
    private int bonusRollsAvailable;
    private readonly ScoreSystem scoring;

    public event Action<Frame> OnFrameComplete;
    public event Action OnFramesCompleted;

    public Player()
    {
        Frames = new Frame[Constants.framesPerMatch];
        for (var i = 0; i < Frames.Length; i++)
        {
            Frames[i] = new Frame(i);
        }

        scoring = new ScoreSystem(Frames);

        remainingRolls = 3;
    }

    public void Roll(int score)
    {
        if (score > Constants.maxRollScore)
        {
            throw new ArgumentOutOfRangeException(string.Format("Score cannot be more than {0}.", Constants.maxRollScore));
        }
    }
}
