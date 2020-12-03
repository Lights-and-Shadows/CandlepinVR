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
}
