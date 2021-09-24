using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //public GameObject spherePower;
    public GameObject pickupEffect;
    public GameObject [] Launcher;
    public GameObject powerUpUIBlocker;

    public GameObject deathScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            Launcher[0].SetActive(true);
            Pickup();
        }
        if(other.tag == "AICar")
        {
            Launcher[1].SetActive(true);
            AIPickup();
        }
    }
    //Method which instantiate pick up effect call car or AI Launcher and destroy the power-up obejct
    void Pickup()
    {
        //Spwan Effects
        Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);
        powerUpUIBlocker.SetActive(false);
        //Apply effect to the  car
        StartCoroutine(Laucher());
    }
    //Launcher which call BulletFollow script to launch the rocket
    IEnumerator Laucher()
    {
        BulletFollow.isCarFiring = true;
        BulletFollow.isPlayerCar = true;
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }

    void AIPickup()
    {
        //Spwan Effects
        Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);
        //Apply effect to the  car
        StartCoroutine(AILaucher());
    }

   


    IEnumerator AILaucher()
    {

        deathScreen.SetActive(true);
        BulletFollow.isAIFiring = true;
        yield return new WaitForSeconds(0.01f);
        //BulletFollow.isAIFiring = false;
        Destroy(gameObject);
    }
}
    