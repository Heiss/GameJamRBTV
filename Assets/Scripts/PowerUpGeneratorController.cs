using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGeneratorController : MonoBehaviour {

    public int maxCountPowerup = 1;
    public List<GameObject> capsules;

    private Vector3 origin = Vector3.zero;
    private Bounds area;

    // Use this for initialization
    void Start()
    {
        Vector3 vec = GetComponent<BoxCollider>().size;
        area = new Bounds(origin, vec);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Kill all upgrades, that are out of bounds
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            if (!area.Contains(go.transform.position))
            {
                Destroy(go);
            }
        }

        // Create new Powerup
        if(transform.childCount < maxCountPowerup)
        {
            // Don't spam Powerups
            int rand = Random.Range(0, 100);
            if(rand > 90)
            {
                SpawnPowerup();
            }
            
        }
    }

    void SpawnPowerup()
    {
        // Get a ramdom powerup
        int rand = Random.Range(0, capsules.Count);
        GameObject randomGO = capsules[rand];

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

        if (area.IntersectRay(ray, out distance))
        {
            Debug.DrawRay(Vector3.zero, direction * distance, Color.yellow, 2);
            return ray.GetPoint(distance * 0.9f);
        }

        // hier wird explizit nicht zero genommen, da sonst vllt der erste Spawn fehlschlägt. Daher der äußerste Rand für solche Bugs!
        return new Vector3(area.size.x * 0.9f, 0, 0);
    }
}
