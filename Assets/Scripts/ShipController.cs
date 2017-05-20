using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    // Public Variables for optimization in Unity IDE
    public float speed;

    private Rigidbody rb;
    private Transform tr;


    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.3F;

    private float nextFire = 0.5F;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            //Instantiate two new laser

            Instantiate(shot, shotSpawn.GetChild(0).position, shotSpawn.rotation);
            Instantiate(shot, shotSpawn.GetChild(1).position, shotSpawn.rotation);

        }
    }


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
        Vector3 rotation = new Vector3(0.0f, speed/2*moveAxis, 0.0f);
        Quaternion deltaRotation = Quaternion.Euler(rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Calculate direction and move the ship
        Vector3 movement = new Vector3(
            moveFrontal * Mathf.Sin(tr.rotation.ToEuler().y), 
            0.0f,
            moveFrontal * Mathf.Cos(tr.rotation.ToEuler().y));
        rb.velocity = movement * speed;
        
        
        
    }
}
