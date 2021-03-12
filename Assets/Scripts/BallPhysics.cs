using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public Rigidbody rb;
    public ScoreSystem system;

    public bool IsRolled;
    // Start is called before the first frame update
    void Start()
    {
        rb.maxAngularVelocity = 200f;

        IsRolled = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!IsRolled)
        {
            if (collision.transform.tag == "Lane")
            {
                IsRolled = true;
                system.rollsRemaining--;
                StartCoroutine(InitScorechecker());
            }
        }
    }

    public IEnumerator InitScorechecker()
    {
        yield return new WaitForSeconds(5f);

        system.CheckScore();
    }
}
