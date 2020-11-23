using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ball;
    public Transform ballSpawnLoc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Destroy(other.gameObject, 3f);
            Instantiate(ball, ballSpawnLoc);
        }
    }

}
