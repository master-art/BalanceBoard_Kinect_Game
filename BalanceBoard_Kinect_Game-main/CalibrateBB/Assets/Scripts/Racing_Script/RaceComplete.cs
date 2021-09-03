using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class RaceComplete : MonoBehaviour
{
    public GameObject myCar;
    public GameObject aiCar;
    public GameObject [] finishCam;
    public GameObject viewModes;
    public GameObject completeTrig;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "AICollider")
        {
            Debug.Log("Inside AICar_RaceComplete");
            StartCoroutine(AICameraView());
        }
        else if(other.name == "Sphere")
        {
            Debug.Log("Inside Car_RaceComplete");
            StartCoroutine(CameraView());
        }
       
        
    }

    IEnumerator CameraView()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<BoxCollider>().enabled = false;
        myCar.SetActive(false);
        completeTrig.SetActive(false);
        CarController.m_Topspeed = 0.0f;
        aiCar.GetComponent<CarAudio>().enabled = false;
        myCar.GetComponent<PCarController>().enabled = false;
        myCar.SetActive(true);
        aiCar.SetActive(false);
        finishCam[0].SetActive(true);
        viewModes.SetActive(false);
    }

    IEnumerator AICameraView()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<BoxCollider>().enabled = false;
        myCar.SetActive(false);
        completeTrig.SetActive(false);
        CarController.m_Topspeed = 0.0f;
        aiCar.GetComponent<CarAudio>().enabled = false;
        myCar.GetComponent<PCarController>().enabled = false;
        myCar.SetActive(false);
        finishCam[1].SetActive(true);
        viewModes.SetActive(false);
    }
}
