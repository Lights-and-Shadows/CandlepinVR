using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.maxAngularVelocity = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
