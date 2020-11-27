using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPhysics : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<Rigidbody>().solverVelocityIterations = 10;
    }
}
