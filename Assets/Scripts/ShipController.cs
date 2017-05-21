using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    // Public Variables for optimization in Unity IDE
    public float speed;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.3F;
    public GameObject explosionEffectPrefab;
    public string specialItemName;
    public GameObject specialItem;

    public string fire;
    public string spec;
    public string horizontal;
    public string vertical;
    

    private Rigidbody rb;
    private Transform tr;

    // Store the boundary of the area
    private Bounds area;

    // Change fire rate (upgradey maybe)
    private float nextFire = 0.5F;

    // Initialize ship
    void Start()
    {
        nextFire += Time.time;

        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        //GameObject go = GameObject.Find("Background");
        //area = new Bounds(Vector3.zero, (new Vector3(go.transform.localScale.x, 100, go.transform.localScale.y)));
        //BoxCollider coll = GameObject.Find("ControllerAsteroid").GetComponent<BoxCollider>();

        Vector3 vec = GameObject.Find("ControllerAsteroid").GetComponent<BoxCollider>().size;
        Debug.Log(vec);
        area = new Bounds(Vector3.zero, new Vector3(vec.x - 15, vec.y, vec.z - 15));

        // No Item attached
        specialItemName = "";
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(area.center, area.size);
    }

    void Update()
    {
        if (Input.GetButton(fire) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            //Instantiate two new laser
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            Instantiate(shot, shotSpawn.GetChild(0).position, shotSpawn.rotation);
            Instantiate(shot, shotSpawn.GetChild(1).position, shotSpawn.rotation);

        }

        if (Input.GetButton(spec))
        {
            Debug.Log("Special Attack");
            

            //Launch a special attack if you got an item
            if (specialItemName == "PlasmaBomb")
            {
                this.PlantPlasmaBomb(); // BOOM!! =)
            }

            if(specialItemName == "LightJump")
            {
                this.LightJump();
            }

        }
    }
    void LightJump()
    {
        Instantiate(specialItem, gameObject.transform.position, shotSpawn.rotation);
        this.specialItemName = "";

        rb.AddRelativeForce(Vector3.forward * 800,ForceMode.Impulse);

    }

    void PlantPlasmaBomb()
    {
        Instantiate(specialItem, gameObject.transform.position , shotSpawn.rotation);
        this.specialItemName = "";
    }


    // Update is called once per frame
    void FixedUpdate () {

        // Get Keyboard Input
        float moveFrontal = Input.GetAxis(vertical);
        float moveAxis = Input.GetAxis(horizontal);
        
        // Rotate the ship
        Vector3 rotation = new Vector3(0.0f, speed/2*moveAxis, 0.0f);
        Quaternion deltaRotation = Quaternion.Euler(rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);

       
        // Calculate direction and move the ship
        Vector3 movement = new Vector3(
            moveFrontal * Mathf.Sin(tr.rotation.ToEuler().y), 
            0.0f,
            moveFrontal * Mathf.Cos(tr.rotation.ToEuler().y));
        rb.velocity = movement * speed;


        // Check Bounds
        if (!area.Contains(this.transform.position))
        {
            //Store coordinates
            float x = tr.position.x;
            float y = tr.position.y;
            float z = tr.position.z;
            Quaternion rot = tr.rotation;

            if (x > area.max.x)
            {
                tr.SetPositionAndRotation(new Vector3(area.min.x, y, tr.position.z), rot);
            }

            if(x < area.min.x)
            {
                tr.SetPositionAndRotation(new Vector3(area.max.x, y, tr.position.z), rot);
            }
            if (z > area.max.z)
            {
                tr.SetPositionAndRotation(new Vector3(tr.position.x, y, area.min.z), rot);
            }

            if (z < area.min.z)
            {
                tr.SetPositionAndRotation(new Vector3(tr.position.x, y, area.max.z), rot);
            }



        }

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.StartsWith("Asteroid"))
        {
            // Destroy asteroid and the ship
            collision.gameObject.SendMessage("destroyMessage");
            this.destroyMessage();
        }
    }

    private void OnDestroy()
    {
        // Destory Sound
        //AudioSource audio = GameObject.Find("ControllerAsteroid").GetComponents<AudioSource>()[1];
        //audio.Play();

        //explode();
    }

    public void destroyMessage()
    {
        // Destory Sound
        AudioSource audio = GameObject.Find("GUIController").GetComponents<AudioSource>()[1];
        audio.Play();

        explode();
        Destroy(gameObject);
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

    public void setSpecialItem(string itemName, GameObject item )
    {
        this.specialItem = item;
        this.specialItemName = itemName;
    }
}
