using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour {

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
        if (Time.fixedTime - initTime > 2)
        {
            Destroy(gameObject);
        }
    }


}
