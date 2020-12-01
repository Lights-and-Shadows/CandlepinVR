using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    int box = 0;
    int roll = 0;
    int[] boxData = new int[3];
    Box currentBox;

    List<Box> summary = new List<Box>(10);

    // Adding the score

    public void AddScore(int pins)
    {
        boxData[roll] = pins;

        NextRoll();
    }

    void NextRoll()
    {
        currentBox = new Box(boxData[0], boxData[1], boxData[2]);

        roll++;

        bool finished = roll == 3 || currentBox.IsStrike || currentBox.IsSpare;

        if (finished)
        {
            summary.Add(currentBox);
            roll = 0;
            box++;
        }

    }

    int GetTotalScore()
    {
        int score = 0;
        foreach(var box in summary)
        {
            score += box.Total;
        }
        return score;
    }

    struct Box
    {
        int a;
        int b;
        int c;

        public Box(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public int Total { get { return a + b + c; } }

        public bool IsStrike {  get { return a == 10; } }
        public bool IsSpare { get { return a + b == 10; } }
    }
}
