using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    
    public CoinHandler CH;
    public GameObject pickupEffect;
    private void Start()
    {
        CH = GameObject.Find("StarCount").GetComponent<CoinHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(Instantiate(pickupEffect, transform.position, transform.rotation), 1f);
            CH.score++;
            Debug.Log("Score in Text Box" + CH.score);

            Destroy(gameObject, 1f);
        }
    }
}
