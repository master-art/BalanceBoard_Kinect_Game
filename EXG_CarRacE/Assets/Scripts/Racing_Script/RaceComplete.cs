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
            StartCoroutine(AICameraView());
        }
        else if(other.name == "Sphere")
        {
            StartCoroutine(CameraView());
        }
       
        
    }

    //Activate Win Screen and Effect for Player car
    IEnumerator CameraView()
    {
        FindObjectOfType<AudioManager>().Play("AudianceClap");
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

    //Activate Win Screen and Effect for NPC car
    IEnumerator AICameraView()
    {
        FindObjectOfType<AudioManager>().Play("AudianceClap");
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
