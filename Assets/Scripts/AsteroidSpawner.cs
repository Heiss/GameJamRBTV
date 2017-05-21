using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    private int maxCountAsteroids = 10;
    public List<GameObject> asteroidAssets;

    public int asteroidAreaOffset = 15;
    public float timeForNextAstroid = 5;
    private float timerSinceLastAstroid;

    private Vector3 origin = Vector3.zero;
    private Bounds area, b;


    // Use this for initialization
    void Start () {
        Camera camera = Camera.main;
        b = getCameraBounds(camera);
        
        BoxCollider coll = GetComponent<BoxCollider>();
        coll.size = new Vector3(b.size.x + asteroidAreaOffset, 10, b.size.y + asteroidAreaOffset);

        Vector3 vec = coll.size;
        area = new Bounds(origin, vec);

        if(GameObject.Find("MenuCanvas") != null)
        {
            maxCountAsteroids = 10;
        }
            else
        {
            maxCountAsteroids = (int)((area.size.x * area.size.z) / (((75 * 75) / maxCountAsteroids)));
            Debug.Log("Calculated Asteroid: " + maxCountAsteroids);

        }

        timerSinceLastAstroid = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(b.center, b.size);
    }

    private Bounds getCameraBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(GameObject.Find("MenuCanvas") == null && Time.time > timerSinceLastAstroid + timeForNextAstroid)
        {
            maxCountAsteroids++;
            timerSinceLastAstroid = Time.time;
            Debug.Log("Erhöht asteroid");
        }

        // alle Asteroidenkinder überprüfen, ob sie in den Abmessungen sind.
		for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            
            // wenn der asteroid nicht mehr in den Bounds ist, wird er zerstört
            if(!area.Contains(go.transform.position))
            {
                //Destroy(go);
                go.SendMessage("destroyMessage");
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

        go.SendMessage("ForceToCenter");
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
            Debug.DrawRay(Vector3.zero, direction * distance, Color.yellow, 2);
            return ray.GetPoint(distance * 0.9f);
        }

        // hier wird explizit nicht zero genommen, da sonst vllt der erste Spawn fehlschlägt. Daher der äußerste Rand für solche Bugs!
        return new Vector3(area.size.x * 0.9f, 0, 0);
    }
}
