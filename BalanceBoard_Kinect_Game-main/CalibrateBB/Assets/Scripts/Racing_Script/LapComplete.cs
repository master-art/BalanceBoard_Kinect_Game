using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject lapCompleteTrig;
    public GameObject halfLapTrig;

    [Header("Display")]
    public GameObject MinuteDB;
    public GameObject SecondDB;
    public GameObject MilliDB;

    //public GameObject LapTimeBox;

    public GameObject lapCounter;

    public int AIlapsDone = 0;
    public int lapsDone = 0;

    public float rawTime;

    public GameObject raceFinish;


    private void OnTriggerEnter()
    {
        lapsDone += 1;
        if (lapsDone == 2)
        {
            Debug.Log("Active Race Line");
            raceFinish.SetActive(true);
        }
        rawTime = PlayerPrefs.GetFloat("RawTime");
        if (LapTimeManager.rawTime <= rawTime)
        {
            if (LapTimeManager.SecondCount <= 9)
            {
                SecondDB.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
            }
            else
            {
                SecondDB.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
            }

            if (LapTimeManager.MinuteCount <= 9)
            {
                MinuteDB.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
            }
            else
            {
                MinuteDB.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ":";
            }

            MilliDB.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount;

        }

        PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
        PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
        PlayerPrefs.SetFloat("MilliSave", LapTimeManager.MiliCount);
        PlayerPrefs.SetFloat("RawTime", LapTimeManager.rawTime);


        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MiliCount = 0;
        LapTimeManager.rawTime = 0;
        lapCounter.GetComponent<Text>().text = "" + lapsDone;




        halfLapTrig.SetActive(true);
        lapCompleteTrig.SetActive(false);

    }
}
