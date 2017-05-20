using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public float thrust = 1f;
    private Vector3 direction = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        if(direction == Vector3.zero)
        {
            direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            direction.Normalize();

            applyForce();
        }
    }

    // Jetzt soll der Asteroid in die enstprechende Richtung gedrückt werden.
    void applyForce()
    {
        Debug.DrawRay(transform.position, direction * 4, Color.cyan, 5);
        GetComponent<Rigidbody>().velocity = direction * thrust;
    }

    // diese Funktion wird nur aufgerufen vom AsteroidSpawner um den Asteroiden in Richtung Center zu schicken.
    void ForceToCenter()
    {
        float angle = Random.Range(-40f, 40f);
        Vector3 dir = (transform.position * -1).normalized;
        dir = Quaternion.Euler(0, angle, 0) * dir;

        direction = dir;
        Debug.DrawRay(transform.position, direction * 5, Color.magenta, 5);

        applyForce();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, GetComponent<Rigidbody>().velocity, Color.green);
    }
}
