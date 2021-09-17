using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonSelect : MonoBehaviour
{
    public Image imgCircle;
    public UnityEvent MyClick;
    public float totalTime = 2f;
    bool buttonStatus;
    public float buttonTimer;
    public Button button;
    public Image img;
    public GameObject btnLoader;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Inside Button Selection Update" + buttonStatus);
        if (buttonStatus)
        {
            buttonTimer += Time.deltaTime;
            imgCircle.fillAmount = buttonTimer / totalTime;

        }

        Debug.Log("Circle Fill Amount" + imgCircle.fillAmount);

        if (buttonTimer > totalTime)
        {
            StartCoroutine(NextStage());
        }
    }

    public void ButtonOn()
    {
        Debug.Log("Inside Button on");
        buttonStatus = true;
        btnLoader.SetActive(true);
    }


    public void ButtonOff()
    {
        Debug.Log("Inside Button off");
        button.GetComponent<Image>().color = new Color(0.06f, 0.16f, 0.2f);
        btnLoader.SetActive(false);
        buttonStatus = false;
        buttonTimer = 0;
        imgCircle.fillAmount = 0;
    }

    private IEnumerator NextStage()
    {
        img.color = new Color(0, 1, 0);
        yield return new WaitForSeconds(0.2f);
        button.GetComponent<Image>().color = new Color(0, 1, 0);
        yield return new WaitForSeconds(1.8f);
        MyClick.Invoke();
    }
}
