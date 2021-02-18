using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreSystem : MonoBehaviour
{
    public List<PinPhysics> pins;
    public List<BallPhysics> balls;
    public List<Box> boxes;

    private int totalScore;

    public bool BonusScoreActive;

    public int rollsRemaining;

    public int index;

    private void Start()
    {
        index = 0;
        totalScore = 0;

        rollsRemaining = 3;

        BonusScoreActive = false;

        boxes = SetUpScoreboard();
    }

    public List<Box> SetUpScoreboard()
    {
        // Essentially set up an unofficial linked list system using the Box class.

        Box b1 = new Box();
        Box b2 = new Box(b1, null);
        Box b3 = new Box(b2, null);
        Box b4 = new Box(b3, null);
        Box b5 = new Box(b4, null);
        Box b6 = new Box(b5, null);
        Box b7 = new Box(b6, null);
        Box b8 = new Box(b7, null);
        Box b9 = new Box(b8, null);
        Box b10 = new Box(b9, null);

        // Set up all the box connections -- CONVOLUTED, BUT IT WORKS.
        b2.next = b3;
        b3.next = b4;
        b4.next = b5;
        b5.next = b6;
        b6.next = b7;
        b7.next = b8;
        b8.next = b9;
        b9.next = b10;

        List<Box> b = new List<Box>();
        b.Add(b1);
        b.Add(b2);
        b.Add(b3);
        b.Add(b4);
        b.Add(b5);
        b.Add(b6);
        b.Add(b7);
        b.Add(b8);
        b.Add(b9);
        b.Add(b10);

        return b;
    }

    public void CheckScore()
    {
        int currentScore = 0;

        foreach(PinPhysics pin in pins)
        {
            if (pin.knocked && !pin.previouslyHit)
            {
                currentScore++;
                pin.previouslyHit = true;
            }
        }

        switch (rollsRemaining)
        {
            case 2: // First roll
                {
                    if (boxes[index].prev != null) // If this is not the first box
                    {
                        Box boxBefore = boxes[index].prev;

                        if (BonusScoreActive && boxBefore.IsStrike) // If the previous box was a strike
                        {

                            if (boxBefore.prev.IsStrike) // If the box before the last one we rolled was a strike -- second bonus roll essentially
                            {
                                boxBefore.prev.score += currentScore;
                                boxBefore.score += currentScore;
                                BonusScoreActive = false;
                            }
                            else
                            {
                                boxBefore.score += currentScore;
                            }
                            
                        }
                        else if (BonusScoreActive && boxes[index].prev.IsSpare) // If the previous box was a spare
                        {
                            boxes[index].prev.score += currentScore;
                            BonusScoreActive = false;
                        }
                    }

                    if (currentScore == 10)
                    {
                        boxes[index].IsStrike = true;
                        BonusScoreActive = true;
                        Debug.Log("STRIKE!");
                    }
                    boxes[index].score += currentScore;

                    Debug.Log("First roll of Box #" + (index + 1) + ": " + currentScore.ToString());
                    break;
                }
            case 1: // Second roll
                {
                    if (boxes[index].prev != null)
                    {
                        Box boxBefore = boxes[index].prev;

                        if (BonusScoreActive && boxBefore.IsStrike)
                        {
                            boxBefore.score += currentScore;
                            BonusScoreActive = false;
                        }
                    }

                    if (currentScore == 10)
                    {
                        boxes[index].IsSpare = true;
                        BonusScoreActive = true;
                        Debug.Log("SPARE!");
                    }
                    boxes[index].score += currentScore;
                    Debug.Log("Second roll of Box #" + (index + 1) + ": " + currentScore.ToString());
                    break;
                }
            case 0: // Third roll
                {
                    boxes[index].score += currentScore;
                    Debug.Log("Third roll of Box #" + (index + 1) + ": " + currentScore.ToString());
                    break;
                }
        }
    }

    public void CalculateTotal()
    {
        int calculatedScore = 0;

        for (int i = 0; i < index; i++)
        {
            calculatedScore += boxes[i].score;
        }

        totalScore = calculatedScore;

        Debug.Log("Total: " + totalScore.ToString());
    }

    public void NextBox()
    {
        index++;
    }
}


