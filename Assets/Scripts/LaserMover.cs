using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMover : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    private Transform tr;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        rb.velocity = tr.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
