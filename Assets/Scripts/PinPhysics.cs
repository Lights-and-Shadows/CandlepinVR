using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPhysics : MonoBehaviour
{
    public bool knocked; // previouslyHit will be set in another script on a pin-by-pin basis
    private void Start()
    {
        //this.GetComponent<Rigidbody>().solverVelocityIterations = 10;

        knocked = false;
    }

    private void Update()
    {
        if (!knocked)
        {
            if (transform.up.y < 0.5f)
            {
                knocked = true;

                //Debug.Log(gameObject.name + " has been hit.");
            }
        }
    }
}
