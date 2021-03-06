using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarSelection : MonoBehaviour
{
    private GameObject[] carList;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CarSelected");
        carList = new GameObject[transform.childCount];

        //add car models
        for (int i = 0; i < transform.childCount; i++)
            carList[i] = transform.GetChild(i).gameObject;

        //Toggle their view
        foreach (GameObject go in carList)
            go.SetActive(false);


        if (carList[index])
            carList[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLeft()
    {
        carList[index].SetActive(false);
        index--;
 
        if (index < 0)
            index = carList.Length - 1;

        carList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        carList[index].SetActive(false);
        
        index++;
        if (index == carList.Length)
            index = 0;

        carList[index].SetActive(true);
    }

    public void ConfirmBtn()
    {
        PlayerPrefs.SetInt("CarSelected", index);
        if(PCarController.ControlTypeOption == PCarController.ControlType.Keyboard)
        {
            PCarController.ControlTypeOption = PCarController.ControlType.Keyboard;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Track");
        }
        else if (PCarController.ControlTypeOption == PCarController.ControlType.Kinect)
        {
            PCarController.ControlTypeOption = PCarController.ControlType.Kinect;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Track");
        }
        else if (PCarController.ControlTypeOption == PCarController.ControlType.Balanceboard)
        {
            PCarController.ControlTypeOption = PCarController.ControlType.Balanceboard;
            UnityEngine.SceneManagement.SceneManager.LoadScene("BalanceBoard_Calibration");
        }

    }


}
