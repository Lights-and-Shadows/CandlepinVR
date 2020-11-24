using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLane : MonoBehaviour
{
    public List<GameObject> pins, balls, pinSpawns, ballSpawns;

    public void ResetTheLane()
    {
        foreach(GameObject spawn in pinSpawns)
        {
            pins[pinSpawns.IndexOf(spawn)].transform.position = spawn.transform.position;
            pins[pinSpawns.IndexOf(spawn)].transform.rotation = spawn.transform.rotation;
            pins[pinSpawns.IndexOf(spawn)].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        foreach(GameObject spawn in ballSpawns)
        {
            balls[ballSpawns.IndexOf(spawn)].transform.position = spawn.transform.position;
            balls[ballSpawns.IndexOf(spawn)].transform.rotation = spawn.transform.rotation;
            balls[ballSpawns.IndexOf(spawn)].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
