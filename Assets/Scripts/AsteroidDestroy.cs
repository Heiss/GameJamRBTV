using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroy : MonoBehaviour {
    public GameObject childGO;
    public int countChilds;
    public GameObject explosionEffectPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Falls ein Asteroid zerstört wird, so soll er Kinder spawnen lassen
    private void OnDestroy()
    {
        spawnChildAsteroids();
    }

    // Spawnt die Kinder-Asteroiden
    void spawnChildAsteroids()
    {
        // eine explosion
        explode();

        // falls dies der Fall, dann ist es der kleinste Asteroid
        if (childGO == null)
        {
            return;
        }

        // je nachdem wie viele Kinderasteroiden erstellt werden sollen
        for (int i = 0; i < countChilds; i++)
        {
            GameObject go = Instantiate(childGO, transform.position, Quaternion.identity);
            go.transform.SetParent(gameObject.transform.parent);
        }
    }

    // Explode effect
    void explode()
    {
        // erst erstellen, damit wir die Explosion auch sehen und verwenden können
        GameObject go = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        go.transform.SetParent(GameObject.Find("Explosions").transform);

        // hier wird die Explosion abgespielt
        ParticleSystem ps = go.GetComponent<ParticleSystem>();
        ps.Play();

        // die Explosion wird zweimal ausgeführt. Daher die Hälfte.
        Destroy(go, ps.main.duration / 2);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.StartsWith("Laser"))
        {
            AudioSource audio = GameObject.Find("ControllerAsteroid").GetComponent<AudioSource>();
            audio.Play();

            int player = 1;
            if(collision.gameObject.name.StartsWith("Laser_Blue"))
            {
                player = 2;
            }

            GameObject.Find("GUIController").SendMessage("increasePointsForPlayer", player);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        } else if(collision.gameObject.name.StartsWith("Ship"))
        {
            Debug.Log("You dieded.");
        }
    }

 
}
