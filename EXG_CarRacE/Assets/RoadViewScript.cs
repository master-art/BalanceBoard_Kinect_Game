using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadViewScript : MonoBehaviour
{
    [SerializeField] GameObject GameHandle;
    [SerializeField] GameObject RoadCameraView;

    bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {

        RoadCameraView.SetActive(true);
        GameHandle.SetActive(false);
        FindObjectOfType<AudioManager>().Play("CrowdSound");

        FindObjectOfType<AudioManager>().Play("Claps");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            RoadCameraView.SetActive(false);
            GameHandle.SetActive(true); 
            isActive = false;
        }
    }
}
