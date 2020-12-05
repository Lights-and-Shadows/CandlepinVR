using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public int currentRollNum, curBoxScore, curBox;

    public List<PinPhysics> pins;
    public List<BallPhysics> balls;
    public List<GameObject> boxes;

    private int score;

    private bool gameOver = false;

    private void Start()
    {
        currentRollNum = 0;
        curBox = 0;
        curBoxScore = 0;
        score = 0;
    }

    private void Update()
    {
        if (gameOver)
        {
            EndGame();
        }
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

                if (curBoxScore == 10)
                    boxes[curBox].transform.Find("markText").GetComponent<TextMeshProUGUI>().text = "X";
                else
                    boxes[curBox].transform.Find("fillText").GetComponent<TextMeshProUGUI>().text = curBoxScore.ToString();

                score = score + curBoxScore;
                boxes[curBox].transform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
                break;
            case 2:
                foreach (PinPhysics pin in pins)
                {
                    if (pin.knocked && pin.previouslyHit)
                    {
                        continue;
                    }
                    else
                    {
                        pin.previouslyHit = true;
                        curBoxScore++;
                    }
                }
                if (curBoxScore == 10)
                    boxes[curBox].transform.Find("markText").GetComponent<TextMeshProUGUI>().text = "/";
                else
                    boxes[curBox].transform.Find("fillText").GetComponent<TextMeshProUGUI>().text = curBoxScore.ToString();

                score = score + curBoxScore;
                boxes[curBox].transform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
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
                boxes[curBox].transform.Find("fillText").GetComponent<TextMeshProUGUI>().text = curBoxScore.ToString();
                boxes[curBox].transform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
                score = score + curBoxScore;
                break;
        }
    }

    private void EndGame()
    {
        curBox = 0;
        curBoxScore = 0;
        currentRollNum = 0;
        score = 0;
    }
}
