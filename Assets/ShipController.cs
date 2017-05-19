using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    // Public Variables for optimization in Unity IDE
    public float speed;

    private Rigidbody rb;
    private Transform tr;

    // Initialize ship
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        // Get Keyboard Input
        float moveFrontal = Input.GetAxis("Vertical");
        float moveAxis = Input.GetAxis("Horizontal");

        // Rotate the ship
        Vector3 rotation = new Vector3(0.0f, moveAxis, 0.0f);
        Quaternion deltaRotation = Quaternion.Euler(rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Calculate direction and move the ship
        Vector3 movement = new Vector3(
            moveFrontal * Mathf.Sin(tr.rotation.ToEuler().y), 
            0.0f,
            moveFrontal * Mathf.Cos(tr.rotation.ToEuler().y));
        print(tr.rotation.ToEuler().y);
        rb.velocity = movement * speed;
        
        
        
    }
}
