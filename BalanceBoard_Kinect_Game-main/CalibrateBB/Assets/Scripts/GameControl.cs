using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject Kinect;
    public GameObject Keyboard;


    // Update is called once per frame
    void Update()
    {
        if(PCarController.ControlTypeOption == PCarController.ControlType.Keyboard)
        {
            Keyboard.SetActive(true);
            Kinect.SetActive(false);
        }
        else
        {
            Kinect.SetActive(true);
            Keyboard.SetActive(false);
        }
    }
}
