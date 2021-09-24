using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class GameHandler : MonoBehaviour
{
    public GameObject countDown;
    public GameObject countDownBG;
    public GameObject LapTimer;
    public GameObject carControls;
    public GameObject handGuide;
    public GameObject balanceBoardGuide;
    public GameObject KeyboardGuide;
    public GameObject[] aICarControl;
    public Animator anim;
    public GameObject ItemInfo;
   // public GameObject trackView;

    private void Start()
    {
        
        //Sound for crowd cheering and claps are played
        FindObjectOfType<AudioManager>().Play("CrowdSound");

        FindObjectOfType<AudioManager>().Play("Claps");


        //According to controller option recieved from previous scene the UI part of that type controller get activate
        if (PCarController.ControlType.Keyboard == PCarController.ControlTypeOption)
        {
            handGuide.SetActive(false);
            balanceBoardGuide.SetActive(false);
            KeyboardGuide.SetActive(true);
            //Debug.Log("Let Deactivate Hand Movement UI");
            StartCoroutine(CountStart());
        }
        else if (PCarController.ControlType.Kinect == PCarController.ControlTypeOption)
        {
            KeyboardGuide.SetActive(false);
            balanceBoardGuide.SetActive(false);
            handGuide.SetActive(true);
            StartCoroutine(KinectCountStart());
        }

        else if (PCarController.ControlType.Balanceboard == PCarController.ControlTypeOption)
        {
            handGuide.SetActive(false);
            KeyboardGuide.SetActive(false);
            balanceBoardGuide.SetActive(true);
            StartCoroutine(CountStart());
        }
    }

    //Handles all Kinect side UI activation and deactivation for race track at the start of the game 
    [System.Obsolete]
    IEnumerator KinectCountStart()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Inside Kinect Count Start");
        handGuide.SetActive(true);
        yield return new WaitForSeconds(3f);
        handGuide.SetActive(false);
        //BodySourceView.isInstantiate = false;
        ItemInfo.SetActive(true);
        yield return new WaitForSeconds(5f);
        ItemInfo.SetActive(false);
        //KeyboardUICheck();
        //yield return new WaitForSeconds(30f);
        //if (trackView.active)
        //{
        //    trackView.SetActive(false);
        //}
        countDownBG.SetActive(true);
        FindObjectOfType<AudioManager>().Play("CountDownSound");
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
        FindObjectOfType<AudioManager>().Stop("CrowdSound");
        yield return new WaitForSeconds(1);
        anim.Play("PlayerUIAnim");
        countDown.SetActive(false);
        countDownBG.SetActive(false);
        LapTimer.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        carControls.GetComponent<PCarController>().enabled = true;


    }

    //Handles all keyboard and kinect side UI activation and deactivation for race track at the start of the game 
    [System.Obsolete]
    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(3f);
        KeyboardGuide.SetActive(false);
        balanceBoardGuide.SetActive(false);
        ItemInfo.SetActive(true);
        yield return new WaitForSeconds(5f);
        ItemInfo.SetActive(false);
        //KeyboardUICheck();
        //yield return new WaitForSeconds(30f);
        //if (trackView.active)
        //{
        //    trackView.SetActive(false);
        //}
        countDownBG.SetActive(true);
        FindObjectOfType<AudioManager>().Play("CountDownSound");
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
        anim.Play("PlayerUIAnim");
        countDown.SetActive(false);
        countDownBG.SetActive(false);
        LapTimer.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        carControls.GetComponent<PCarController>().enabled = true;
        FindObjectOfType<AudioManager>().Stop("CrowdSound");
    }

    //public void KeyboardUICheck()
    //{
    //    trackView.SetActive(true);
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        trackView.SetActive(false);
    //    }
    //}

    [System.Obsolete]
    public void CallKinectControl()
    {
                StartCoroutine(KinectCountStart());
    }
}
