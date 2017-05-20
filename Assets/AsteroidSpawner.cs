using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    public int maxCountAsteroids;
    public List<GameObject> asteroidAssets;
    public Vector3[] playableArea = new Vector3[2];

    private Vector3 origin = Vector3.zero;
    private Bounds area;

    // Use this for initialization
    void Start () {
        area = new Bounds(origin, (playableArea[1] - playableArea[0]) / 2);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // alle Asteroidenkinder überprüfen, ob sie in den Abmessungen sind.
		for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            
            // wenn der asteroid nicht mehr in den Bounds ist, wird er zerstört
            if(!area.Contains(go.transform.position))
            {
                Destroy(go);
            }
        }

        // erstelle neue Asteroiden um die Anzahl beizubehalten.
        for (int i = 0; i < maxCountAsteroids - transform.childCount; i++)
        {
            spawnAsteroid();
        }
    }

    void spawnAsteroid()
    {
        /* Hier können verschiedene Größen genommen werden*/
        int rand = Random.Range(0, asteroidAssets.Count);
        GameObject randomGO = asteroidAssets[rand];

        // Spawn that shit
        GameObject go = Instantiate(randomGO, findSpawnPoint(), Quaternion.identity);
        go.transform.SetParent(gameObject.transform);
    }

    Vector3 findSpawnPoint()
    {
        // erstmal eine Richtung generieren lassen
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        direction.Normalize();

        Ray ray = new Ray(origin, direction);
        float distance = 0;

        if(area.IntersectRay(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        return origin;
    }
}
