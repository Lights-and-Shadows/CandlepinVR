using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public Rigidbody rb;

    public ScoreSystem scoring;

    public bool hasBeenRolled;
    // Start is called before the first frame update
    void Start()
    {
        rb.maxAngularVelocity = 50f;
        hasBeenRolled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lane" && !hasBeenRolled)
        {
            hasBeenRolled = true;
            scoring.currentRollNum++;
            //Debug.Log(scoring.currentRollNum);
            StartCoroutine(InvokeScoring());
        }
    }

    public IEnumerator InvokeScoring()
    {
        yield return new WaitForSeconds(7f);
        //Debug.Log("Time to check the score.");
        scoring.CheckScore();
    }
}
