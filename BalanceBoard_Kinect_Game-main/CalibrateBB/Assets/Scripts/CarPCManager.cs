using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPCManager : MonoBehaviour
{
    public int carNumber;
    public int pcCrossed = 0;
    public int carPosition;

    public RaceManager raceManger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PC"))
        {
            pcCrossed += 1;
            if(pcCrossed == 32)
            {
                pcCrossed = 0;
            }
            raceManger.CarCollectedPc(carNumber, pcCrossed);
        }
    }
}
