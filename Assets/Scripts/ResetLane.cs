using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ResetLane : MonoBehaviour
{
    public List<GameObject> pins, balls, pinSpawns, ballSpawns, pinPhys, ballPhys;
    public ScoreSystem system;
    public void ResetTheLane()
    {

        // Reset all moveable objects back to starting positions in scene + remove any current forces on them.
        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].transform.position = pinSpawns[i].transform.position;
            pins[i].transform.rotation = pinSpawns[i].transform.rotation;
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            pins[i].GetComponent<PinPhysics>().knocked = false;
        }

        for (int j = 0; j < balls.Count; j++)
        {
            balls[j].transform.position = ballSpawns[j].transform.position;
            balls[j].transform.rotation = ballSpawns[j].transform.rotation;
            balls[j].GetComponent<Rigidbody>().velocity = Vector3.zero;
            balls[j].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            balls[j].GetComponent<BallPhysics>().IsRolled = false;
        }

        system.rollsRemaining = 3;
        system.NextBox();
        system.CalculateTotal();
    }
}
