using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGenerator : MonoBehaviour {

    private float initTime;

    // Use this for initialization
    void Start()
    {
        initTime = Time.fixedTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Kill blast after a few seconds
        if (Time.fixedTime - initTime > 0.7)
        {
            Destroy(gameObject);
        }
    }

    // Pull everything to the core
    void OnTriggerStay(Collider collision)
    {
        Vector3 center = gameObject.GetComponent<Transform>().position;
        if ((Time.fixedTime - initTime > 0.3) && (collision.gameObject.name.StartsWith("Asteroid") || collision.gameObject.name.StartsWith("Ship")))
        {
            Vector3 collisionPosition = collision.GetComponent<Transform>().position;
            collision.GetComponent<Rigidbody>().AddForce(center-collisionPosition, ForceMode.Impulse);
        }
    }
}
