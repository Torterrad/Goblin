using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public FoodMovement food;
    public Spawner foodSpawner;
    public NutSpawner nutSpawner;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Pickup();
            }
        }
    }

    void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
