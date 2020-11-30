using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int rollsPerBox = 3;
    public int currentRollNum = 0, curBoxScore;

    private int maxRolls = 30;
    private int maxBoxes = 10;

    public List<PinPhysics> pins;

    private int score;

    private void Start()
    {
        currentRollNum = 0;
        curBoxScore = 0;
        score = 0;
    }

    public void CheckScore()
    {
        switch (currentRollNum)
        {
            case 1:
                foreach (PinPhysics pin in pins)
                {
                    if (pin.knocked)
                    {
                        pin.previouslyHit = true;
                        curBoxScore++;
                    }
                }
                score = curBoxScore;
                break;
            case 2:
                foreach (PinPhysics pin in pins)
                {
                    if (pin.knocked && pin.previouslyHit)
                        continue;
                    else
                    {
                        pin.previouslyHit = true;
                        curBoxScore++;
                    }
                }
                score = score + curBoxScore;
                break;
            case 3:
                foreach (PinPhysics pin in pins)
                {
                    if (pin.knocked && pin.previouslyHit)
                        continue;
                    else
                    {
                        pin.previouslyHit = true;
                        curBoxScore++;
                    }
                }
                score = score + curBoxScore;
                break;
        }
    }
}
