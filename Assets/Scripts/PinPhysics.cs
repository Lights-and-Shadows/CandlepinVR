using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPhysics : MonoBehaviour
{
    public bool knocked; // previouslyHit will be set in another script on a pin-by-pin basis
    public bool previouslyHit;

    public Transform detector;


    private void Start()
    {
        //this.GetComponent<Rigidbody>().solverVelocityIterations = 10;

        knocked = false;
        previouslyHit = false;
    }

    private void Update()
    {
        RaycastHit hit;

        if (!knocked)
        {
            if (Physics.Raycast(detector.position, detector.up, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Detector")
                {
                    knocked = true;

                    Debug.Log(gameObject.name + " has been hit.");
                }
            }
        }
    }
}
