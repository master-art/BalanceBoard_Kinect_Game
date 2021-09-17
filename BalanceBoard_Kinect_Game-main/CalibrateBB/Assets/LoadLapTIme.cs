using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadLapTIme : MonoBehaviour
{
    public int MinCount;
    public int SecCount;
    public float MiliCount;
    [SerializeField] private GameObject MinDisplay;
    [SerializeField] private GameObject SecDisplay;
    [SerializeField] private GameObject MiliDisplay;
    // Start is called before the first frame update
    void Start()
    {
        MinCount = PlayerPrefs.GetInt("MinSave");
        SecCount = PlayerPrefs.GetInt("SecSave");
        MiliCount = PlayerPrefs.GetInt("MiliSave");

        MinDisplay.GetComponent<Text>().text = "" + MinCount + ":";
        SecDisplay.GetComponent<Text>().text = "" + SecCount + ".";
        MiliDisplay.GetComponent<Text>().text = "" + MiliCount;

    }
}
