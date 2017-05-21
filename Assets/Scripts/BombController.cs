using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    private float initTime;
    private bool soundPlayed = false;

	// Use this for initialization
	void Start () {
        initTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
        // kurz vor Zerstörung sound abspielen lassen
        if(!soundPlayed && Time.fixedTime - initTime > 1.9)
        {
            GameObject.Find("PowerUpGenerator").GetComponent<AudioSource>().Play();
            soundPlayed = true;
        }
        if(Time.fixedTime - initTime > 2.2)
        {
            Destroy(gameObject);
        }
	}


    void OnTriggerStay(Collider collision)
    {
        if ((Time.fixedTime - initTime > 2) && (collision.gameObject.name.StartsWith("Asteroid") || collision.gameObject.name.StartsWith("Ship")))
        {
            gameObject.SendMessage("destroyMessage");
            //Destroy(collision.gameObject);
            collision.SendMessage("destroyMessage");
        }
    }
}
