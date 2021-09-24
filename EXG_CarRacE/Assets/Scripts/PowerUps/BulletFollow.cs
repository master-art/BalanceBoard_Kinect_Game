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

    public static bool isAIFiring = false, isCarFiring= false, isPlayerCar = false;

   [SerializeField] private GameObject RocketUIBlocker;

    private void Update()
    {
        if (isAIFiring)
        {
            isAIFiring = false;
            GameObject rocket = Instantiate(rocketPrefab, spawnPosition.transform.position, rocketPrefab.transform.rotation);
            rocket.transform.LookAt(target.transform);
            StartCoroutine(SendAIHoming(rocket));
        }
        if (isCarFiring)
        {
            isCarFiring = false;
            GameObject rocket = Instantiate(rocketPrefab, spawnPosition.transform.position, rocketPrefab.transform.rotation);
            rocket.transform.LookAt(target.transform);
            StartCoroutine(SendCarHoming(rocket));
        }

    }
    public IEnumerator SendAIHoming(GameObject rocket)
    {
        while (Vector3.Distance(target.transform.position, rocket.transform.position) > 0.3f)
        {
            rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(target.transform);
            yield return null;
        }
            Destroy(Instantiate(explosionEffect, rocket.transform.position, rocket.transform.rotation), 1f);
            if(rocket.tag == "AIRocket")
            {
                Destroy(rocket);
            }

        FindObjectOfType<AudioManager>().Play("RocketBlast");
        StartCoroutine(CarDestroy());
        if (GameObject.Find("AIPowersUI") != null)
        {
            GameObject.Find("AIPowersUI").SetActive(false);
        }
    }
    IEnumerator CarDestroy()
    {
        GameObject.Find("CarSubset").GetComponent<PCarController>().maxSpeed = 100;
        target.SetActive(false);
        yield return new WaitForSeconds(2f);
        GameObject.Find("CarSubset").GetComponent<PCarController>().maxSpeed = 6200;
        CarRespawnEffect();
    }

    public IEnumerator SendCarHoming(GameObject rocket)
    {

        while (Vector3.Distance(target.transform.position, rocket.transform.position) > 0.3f)
        {
            rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(target.transform);

            yield return null;
        }
        Destroy(Instantiate(explosionEffect, rocket.transform.position, rocket.transform.rotation), 1f);
        if (rocket.tag == "CarRocket")
        {
            Destroy(rocket);
        }
       FindObjectOfType<AudioManager>().Play("RocketBlast");
        StartCoroutine(AIDestroy());

    }

    IEnumerator AIDestroy()
    {
        target.SetActive(false);
        yield return new WaitForSeconds(1f);
        RocketUILock();
        yield return new WaitForSeconds(1f);
        CarRespawnEffect();
    }


    private void CarRespawnEffect()
    {
        target.SetActive(true);
        target.SetActive(false);
        target.SetActive(true);
        target.SetActive(false);
        target.SetActive(true);
        target.SetActive(false);
        target.SetActive(true);
        gameObject.SetActive(false);
    }

    public void RocketUILock()
    {
        if (isPlayerCar)
        {
            RocketUIBlocker.SetActive(true);
            isPlayerCar = false;
        }
    }
}
