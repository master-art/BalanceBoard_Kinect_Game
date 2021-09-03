using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosDown : MonoBehaviour
{
    public GameObject positionDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CarPos")
        {
            positionDisplay.GetComponent<Text>().text = "2nd Place";
        }
    }


}
