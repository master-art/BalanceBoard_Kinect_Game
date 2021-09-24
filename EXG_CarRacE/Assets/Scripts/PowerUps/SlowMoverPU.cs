using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SlowMoverPU : MonoBehaviour
{

    public GameObject pickupEffect;

    public GameObject powerUpUIBlocker;

    public GameObject[] carSpark;

    public GameObject[] carSmoke;


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
    }

    IEnumerator PlayerReduce()
    {
        carSmoke[0].SetActive(false);
        carSpark[0].SetActive(true);
        GameObject.Find("CarSubset").GetComponent<PCarController>().maxSpeed = 500;
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("CarSubset").GetComponent<PCarController>().maxSpeed = 6200;
        carSmoke[0].SetActive(true);
        carSpark[0].SetActive(false);
        powerUpUIBlocker.SetActive(true);
        Destroy(gameObject);
    }

    void AIPickup()
    {
        //Spwan Effects
        Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);
        //Apply effect to the  car
        StartCoroutine(AIReduce());
    }


   

    IEnumerator AIReduce()
    {
        carSmoke[1].SetActive(false);
        carSpark[1].SetActive(true);
        CarController.m_Topspeed = 5f;
        yield return new WaitForSeconds(1.5f);
        CarController.m_Topspeed = 50f;
        carSmoke[1].SetActive(true);
        carSpark[1].SetActive(false);
        Destroy(gameObject);
       
    }
}

//Check Player is ahead of the player or behind 
//if it's behind place player ahead 