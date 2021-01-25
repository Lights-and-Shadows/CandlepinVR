using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreSystem : MonoBehaviour
{
    private List<PinPhysics> pins;
    private List<BallPhysics> balls;
    private GameObject currentBall;
    private bool IsStrike, IsSpare;

    private int currentScore, totalScore;

    private int rollsRemaining;

    private void Start()
    {
        // Populate the lists programmatically
        foreach (GameObject pin in GameObject.FindGameObjectsWithTag("Pin"))
        {
            PinPhysics physics = pin.GetComponent<PinPhysics>();
            pins.Add(physics);
        }

        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            BallPhysics bPhys = ball.GetComponent<BallPhysics>();
            balls.Add(bPhys);
        }

        totalScore = currentScore = 0;

        rollsRemaining = 3;
    }
}


