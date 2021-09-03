using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CountDown : MonoBehaviour
{
    public GameObject countDown;
    public GameObject LapTimer;
    public GameObject carControls;
    public GameObject [] aICarControl;

    private void Start()
    {
        StartCoroutine(CountStart());
    }

   IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        countDown.GetComponent<Text>().text = "3";
        countDown.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "2";
        countDown.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "1";
        countDown.SetActive(true);
        for(int i =0; i< aICarControl.Length; i++)
        {
            aICarControl[i].GetComponent<CarAIControl>().enabled = true;
        }
       
        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        LapTimer.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        carControls.GetComponent<PCarController>().enabled = true;
        
    }
}
