using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    public int maxCountAsteroids;

    public GameObject player;

    private Vector3 middlePoint;

    public List<GameObject> asteroidAssets;
    private List<GameObject> asteroids = new List<GameObject>();

	// Use this for initialization
	void Start () {
        middlePoint = player.transform.position;
        for(int i = 0; i < maxCountAsteroids; i++){
            spawnAsteroids();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnAsteroids()
    {
        /* Hier können verschiedene Größen genommen werden*/
        int rand = Random.Range(0, asteroidAssets.Count);
        Debug.Log(rand);
        GameObject randomGO = asteroidAssets[rand];

        // Spawn that shit
        GameObject go = Instantiate(randomGO, player.transform.position, Quaternion.identity);
        asteroids.Add(go);
    }
}
