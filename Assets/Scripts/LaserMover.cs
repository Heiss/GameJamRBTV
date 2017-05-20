using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMover : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    private Transform tr;

    // Kill the laser eventually
    private float birthtime;
    private float lifetime;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        rb.velocity = tr.forward * speed;

        lifetime = 100.0F;
        birthtime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time - birthtime > lifetime)
        {
            Destroy(gameObject);
        }
	}
}
