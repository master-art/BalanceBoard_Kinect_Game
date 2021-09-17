using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject spherePower;
    public GameObject pickupEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        //Spwan Effects
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply effect to the  car

        //Remove Power-Up Object
        spherePower.SetActive(false);
    }
}
