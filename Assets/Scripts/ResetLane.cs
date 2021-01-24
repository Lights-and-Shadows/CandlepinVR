using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ResetLane : MonoBehaviour
{
    public List<GameObject> pins, balls, pinSpawns, ballSpawns, pinPhys;

    public void ResetTheLane()
    {

        // Reset all moveable objects back to starting positions in scene + remove any current forces on them.
        foreach (GameObject spawn in pinSpawns)
        {
            pins[pinSpawns.IndexOf(spawn)].transform.position = spawn.transform.position;
            pins[pinSpawns.IndexOf(spawn)].transform.rotation = spawn.transform.rotation;
            pins[pinSpawns.IndexOf(spawn)].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[pinSpawns.IndexOf(spawn)].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            pinPhys[pinSpawns.IndexOf(spawn)].GetComponent<PinPhysics>().knocked = false;
            pinPhys[pinSpawns.IndexOf(spawn)].GetComponent<PinPhysics>().previouslyHit = false;
        }

        foreach (GameObject spawn in ballSpawns)
        {
            balls[ballSpawns.IndexOf(spawn)].transform.position = spawn.transform.position;
            balls[ballSpawns.IndexOf(spawn)].transform.rotation = spawn.transform.rotation;
            balls[ballSpawns.IndexOf(spawn)].GetComponent<Rigidbody>().velocity = Vector3.zero;
            balls[ballSpawns.IndexOf(spawn)].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            balls[ballSpawns.IndexOf(spawn)].GetComponent<BallPhysics>().hasBeenRolled = false;
        }

        
    }
}
