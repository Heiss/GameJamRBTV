using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public float thrust = 1f;
    private Rigidbody rb;
    private Vector3 direction;

    // Use this for initialization
    void Start()
    {
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        direction.Normalize();
        rb = GetComponent<Rigidbody>();

        rb.velocity = direction * thrust;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
