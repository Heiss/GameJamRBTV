using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItem : MonoBehaviour {

    public string itemName;
    public GameObject item;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.StartsWith("Ship"))
        {
            // Destroy SpecialItem Container and pass the Item to the ship
            ShipController ship = (ShipController) collision.gameObject.GetComponent("ShipController");
            ship.setSpecialItem(itemName, item);
        
            Destroy(gameObject);
        }
    }
}
