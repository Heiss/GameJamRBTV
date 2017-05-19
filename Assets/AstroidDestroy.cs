using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidDestroy : MonoBehaviour {
    public GameObject childGO;
    public int countChilds;

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
        for (int i = 0; i < countChilds; i++)
        {
            Instantiate(childGO, transform.position, Quaternion.identity);
        }
    }
}
