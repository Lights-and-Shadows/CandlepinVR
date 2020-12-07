using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPhysics : MonoBehaviour
{
    public bool knocked, previouslyHit; // previouslyHit will be set in another script on a pin-by-pin basis

    public ScoreSystem scoring;
    private void Start()
    {
        //this.GetComponent<Rigidbody>().solverVelocityIterations = 10;

        knocked = false;
        previouslyHit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Pin"))
        {
            knocked = true;

            if (!previouslyHit)
            {
                previouslyHit = true;
                scoring.curBoxScore++;
            }
        }

    }
}
