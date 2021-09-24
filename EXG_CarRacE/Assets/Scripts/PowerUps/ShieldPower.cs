using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPower : MonoBehaviour
{
    public GameObject pickupEffect;

    public GameObject powerUpUIBlocker;

    public GameObject[] ShieldActive;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Pickup();
        }

        if (other.tag == "AICar")
        {
            AIPickup();
        }
    }

    void Pickup()
    {
        //Spwan Effects
        Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);
        powerUpUIBlocker.SetActive(false);
        StartCoroutine(PlayerShield());

    }
    IEnumerator PlayerShield()
    {
        ShieldActive[0].SetActive(true);
        ShieldProtectScript.isPlayerShield = true;
        yield return new WaitForSeconds(2f);
        ShieldProtectScript.isPlayerShield = false;
        ShieldActive[0].SetActive(false);
        powerUpUIBlocker.SetActive(true);
        Destroy(gameObject);
    }

    void AIPickup()
    {

        //Spwan Effects
        Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);

        //Apply effect to the  car
        StartCoroutine(AIShield());
    }
    IEnumerator AIShield()
    {
        ShieldActive[1].SetActive(true);
        yield return new WaitForSeconds(2f);
        ShieldActive[1].SetActive(false);
        Destroy(gameObject);
    }
}
