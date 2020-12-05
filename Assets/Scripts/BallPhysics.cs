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
        //hasBeenRolled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lane")
        {
            scoring.currentRollNum++;
            StartCoroutine(InvokeScoring());
        }
    }

    public IEnumerator InvokeScoring()
    {
        yield return new WaitForSeconds(3f);

        scoring.CheckScore();
    }
}
