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

        float angle = Random.Range(-40f, 40f);
        Vector3 dir = (transform.position * -1).normalized;
        dir = Quaternion.Euler(0, angle, 0) * dir;

        Debug.DrawRay(transform.position, dir * 5, Color.cyan, 5);

        rb.velocity = dir * thrust;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, rb.velocity, Color.green);
    }
}
