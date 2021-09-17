using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CountDown : MonoBehaviour
{
    public GameObject countDown;
    public GameObject countDownBG;
    public GameObject LapTimer;
    public GameObject carControls;
    public GameObject handGuide;
    public GameObject [] aICarControl;
    
    private void Start()
    {
        Debug.Log("Which Type of Controller:" + PCarController.ControlTypeOption);
        if (PCarController.ControlType.Kinect != PCarController.ControlTypeOption)
        {
            //Debug.Log("Let Deactivate Hand Movement UI");
            handGuide.SetActive(false);
            StartCoroutine(CountStart());
        }
    }

    private void Update()
    {
        //Debug.Log("Which Type of Controller:" + PCarController.ControlTypeOption);
        if (PCarController.ControlType.Kinect == PCarController.ControlTypeOption)
        {
            if (BodySourceView.isInstantiate)
            {
                Debug.Log("Inside Is Instnatiate");
                StartCoroutine(KinectCountStart());
            }

        }
      
    }
    IEnumerator KinectCountStart()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Inside Kinect Count Start");
        handGuide.SetActive(false);
        BodySourceView.isInstantiate = false;
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
        countDownBG.SetActive(false);
        LapTimer.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        carControls.GetComponent<PCarController>().enabled = true;
        
    }


    IEnumerator CountStart()
    {
        Debug.Log("Inside Keyboard Count Start");
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
        for (int i = 0; i < aICarControl.Length; i++)
        {
            aICarControl[i].GetComponent<CarAIControl>().enabled = true;
        }
        
        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDownBG.SetActive(false);
        LapTimer.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        carControls.GetComponent<PCarController>().enabled = true;

    }
}
