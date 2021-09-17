using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //public GameObject spherePower;
    public GameObject pickupEffect;
    public GameObject [] Launcher;
    public GameObject powerUpUIBlocker;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            Debug.Log("Player Power acquired");
            Launcher[0].SetActive(true);
            Pickup();
            
        }

        if(other.tag == "AICar")
        {
            Debug.Log("AI Power acquired");
            Launcher[1].SetActive(true);
            AIPickup();

        }
    }

    void Pickup()
    {
        
        //Spwan Effects
        Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);
        powerUpUIBlocker.SetActive(false);
        //Apply effect to the  car
        StartCoroutine(Laucher());
        //Remove Power-Up Object
        
        //spherePower.SetActive(false);
    }

    void AIPickup()
    {
       
        //Spwan Effects
        Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);

        //Apply effect to the  car
        StartCoroutine(AILaucher());
        //Remove Power-Up Object

        //spherePower.SetActive(false);
    }

    IEnumerator Laucher()
    {
        BulletFollow.iSFiring = true;
        BulletFollow.isPlayerCar = true;
        yield return new WaitForSeconds(0.01f);
        BulletFollow.iSFiring = false;
        Destroy(gameObject);
    }


    IEnumerator AILaucher()
    {
        BulletFollow.iSFiring = true;
        yield return new WaitForSeconds(0.01f);
        BulletFollow.iSFiring = false;
        Destroy(gameObject);
    }
}
    