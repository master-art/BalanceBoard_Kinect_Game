using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonSelect : MonoBehaviour
{
    [Header("Images")]
    public Image imgCircle;
    public Image img;

    [Header("Event")]
    public UnityEvent MyClick;

    [Header("Timer")]
    public float totalTime = 2f;
    public float buttonTimer;

    [Header("GameObject")]
    public GameObject btnLoader;

    public Button button;

    bool buttonStatus;

    // Update is called once per frame
    void Update()
    {
        //Calls Timer Method
        Timer();

        //Calls InvokeNextStage Method
        InvokeNextStage();
    }

    //Method to calculate 2 second timer 
    public void Timer()
    {
        if (buttonStatus)
        {
            buttonTimer += Time.deltaTime;
            imgCircle.fillAmount = buttonTimer / totalTime;
        }
    }

    //Invoke the NextStage after 2 seconds have passed
    public void InvokeNextStage()
    {
        if (buttonTimer > totalTime)
        {
            StartCoroutine(NextStage());
        }
    }

    //Button to activate Timer
    public void ButtonOn()
    {
        Debug.Log("Inside Button on");
        buttonStatus = true;
        btnLoader.SetActive(true);
    }


    //Button to deactivate Timer and loader
    public void ButtonOff()
    {
        Debug.Log("Inside Button off");
        button.GetComponent<Image>().color = new Color(0.06f, 0.16f, 0.2f);
        btnLoader.SetActive(false);
        buttonStatus = false;
        buttonTimer = 0;
        imgCircle.fillAmount = 0;
    }

    //Method is called provke the SceneManage script to go to next scene
    private IEnumerator NextStage()
    {
        img.color = new Color(0, 1, 0);
        yield return new WaitForSeconds(0.2f);
        button.GetComponent<Image>().color = new Color(0, 1, 0);
        yield return new WaitForSeconds(1.8f);
        MyClick.Invoke();
    }
}
