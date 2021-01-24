using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

internal class ScoreSystem
{
    private Dictionary<Frame, int> markTracker;

    public ScoreSystem(IEnumerable<Frame> frames)
    {
        markTracker = new Dictionary<Frame, int>();
        foreach (var frame in frames)
        {
            markTracker.Add(frame, 0);
        }
    }

    public void TrackRolls(Frame frame, int rollsToTrack)
    {
        markTracker[frame] = rollsToTrack;
    }

    public void HandleRoll(int score)
    {

    }
}


