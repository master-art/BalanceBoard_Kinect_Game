using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;

    [SerializeField] private GameObject spawnPosition;

    [SerializeField] private GameObject target;

    [SerializeField] private float speed;

    [SerializeField] private GameObject explosionEffect;

    public static bool iSFiring = false, isPlayerCar = false;

   [SerializeField] private GameObject RocketUIBlocker;

    private PowerUp pU;

    private void Update()
    {

        if (iSFiring)
        {
            GameObject rocket = Instantiate(rocketPrefab, spawnPosition.transform.position, rocketPrefab.transform.rotation);
            rocket.transform.LookAt(target.transform);
            StartCoroutine(SendHoming(rocket));
        }
            
       
    }


    public IEnumerator SendHoming(GameObject rocket)
    {
        while (Vector3.Distance(target.transform.position, rocket.transform.position) > 0.3f)
        {
            rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(target.transform);
           
            yield return null;
        }
        Destroy(Instantiate(explosionEffect, rocket.transform.position, rocket.transform.rotation), 1f);
        //Destroy(target, 0.5f);
        Destroy(rocket);
        StartCoroutine(CarDestroy());

    }

    IEnumerator CarDestroy()
    {
        target.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        RocketUILock();
        yield return new WaitForSeconds(0.5f);
        target.SetActive(true);
        target.SetActive(false);
        target.SetActive(true);
        target.SetActive(false);
        target.SetActive(true);
        target.SetActive(false);
        target.SetActive(true);
        gameObject.SetActive(false);

    }

    //public void RocketUILock()
    //{
    //    if(RocketUIBlocker == null)
    //    {
    //        Debug.Log("Inside NUll AI Rockt Blocker");
    //        return;
    //    }
    //    RocketUIBlocker.SetActive(true);

    //}

    public void RocketUILock()
    {
        if (isPlayerCar)
        {
            RocketUIBlocker.SetActive(true);
            isPlayerCar = false;
        }
    }


}
