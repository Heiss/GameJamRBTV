﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    private float initTime;

	// Use this for initialization
	void Start () {
        initTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
        if(Time.fixedTime - initTime > 2.2)
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
	}


    void OnTriggerStay(Collider collision)
    {
        if ((Time.fixedTime - initTime > 2) && (collision.gameObject.name.StartsWith("Asteroid") || collision.gameObject.name.StartsWith("Ship")))
        {
            Destroy(collision.gameObject);
        }
    }
}
