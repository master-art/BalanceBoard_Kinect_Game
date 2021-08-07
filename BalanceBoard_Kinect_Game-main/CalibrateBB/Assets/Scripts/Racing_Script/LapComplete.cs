using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject lapCompleteTrig;
    public GameObject halLapTrig;

    [Header("Display")]
    public GameObject MinuteDB;
    public GameObject SecondDB;
    public GameObject MilliDB;

    //public GameObject LapTimeBox;

    private void OnTriggerEnter()
    {
        if (LapTimeManager.SecondCount <= 9)
        {
            SecondDB.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
        } else {
            SecondDB.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
        }

        if (LapTimeManager.MinuteCount <= 9)
        {
            MinuteDB.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
        } else {
            MinuteDB.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ":";
        }

        MilliDB.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount;

        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MiliCount = 0;

        halLapTrig.SetActive(true);
        lapCompleteTrig.SetActive(false);
    }
}
