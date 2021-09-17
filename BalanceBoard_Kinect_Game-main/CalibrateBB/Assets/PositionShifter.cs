using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class PositionShifter : MonoBehaviour
{

    public GameObject pickupEffect;

    public GameObject powerUpUIBlocker;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Power acquired");
            Pickup();

        }

        if (other.tag == "AICar")
        {
            Debug.Log("AI Power acquired");
            AIPickup();

        }
    }

    void Pickup()
    {

        //Spwan Effects
        Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);
        powerUpUIBlocker.SetActive(false);
        StartCoroutine(PlayerReduce());
        //Apply effect to the  car
        
    }

    void AIPickup()
    {

        //Spwan Effects
        Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);

        //Apply effect to the  car
        StartCoroutine(AIReduce());
    }


    IEnumerator PlayerReduce()
    {
        CarController.m_Topspeed = 10f;
        yield return new WaitForSeconds(1f);
        CarController.m_Topspeed = 200f;
        powerUpUIBlocker.SetActive(true);
        Destroy(gameObject);
    }


    IEnumerator AIReduce()
    {
        GameObject.Find("CarSubset").GetComponent<PCarController>().maxSpeed = 500;
        yield return new WaitForSeconds(1f);
        GameObject.Find("CarSubset").GetComponent<PCarController>().maxSpeed = 6000;
        Destroy(gameObject);
    }
}

//Check Player is ahead of the player or behind 
//if it's behind place player ahead 