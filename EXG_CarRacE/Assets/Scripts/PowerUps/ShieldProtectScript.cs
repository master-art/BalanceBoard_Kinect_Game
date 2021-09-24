using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldProtectScript : MonoBehaviour
{
    public static bool isPlayerShield = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (isPlayerShield)
        {
            if (other.tag == "AIRocket")
            {
                Destroy(other.gameObject);
                GameObject.Find("AILauncher").SetActive(false);
                GameObject.Find("AIPowersUI").SetActive(false);
            }
        }
        else
        {
            if (other.tag == "CarRocket")
            {
              
                Destroy(other.gameObject);
                GameObject.Find("CarLauncher").SetActive(false);
            }
        }
       
    }

}
