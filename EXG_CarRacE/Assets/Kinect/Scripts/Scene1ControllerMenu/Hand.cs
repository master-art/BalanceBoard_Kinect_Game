using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [Header("Kinect_Body_Part")]
    GameObject RHandMesh, LHandMesh, HeadMesh;

    private void Start()
    {
        RHandMesh = GameObject.Find("HandRight");
        LHandMesh = GameObject.Find("HandLeft");
        HeadMesh = GameObject.Find("Head");
    }
   
    void Update()   
    {
        LHandMesh.SetActive(false);
        HeadMesh.SetActive(false);
        RaycastSingle();
    }

    //Raycast to trigger button selection
    private void RaycastSingle()
    {
        Vector3 origin = RHandMesh.transform.position;
        Vector3 direction = RHandMesh.transform.forward;

        Debug.DrawRay(origin, direction * 100f, Color.red);
        Ray ray = new Ray(origin, direction);

        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.collider.name == "Keyboard")
                {
                    raycastHit.collider.GetComponent<ButtonSelect>().ButtonOn();
                    raycastHit.collider.GetComponent<Image>().color = new Color(0.12f, 0.5f, 0.6f);
                }
                else if (raycastHit.collider.name == "Kinect")
                {
                    raycastHit.collider.GetComponent<ButtonSelect>().ButtonOn();
                    raycastHit.collider.GetComponent<Image>().color = new Color(0.12f, 0.5f, 0.6f);
                }
                else if(raycastHit.collider.name == "NBB")
                {
                    raycastHit.collider.GetComponent<ButtonSelect>().ButtonOn();
                    raycastHit.collider.GetComponent<Image>().color = new Color(0.12f, 0.5f, 0.6f);
                }
            }
            else
            {
                GameObject.Find("Keyboard").GetComponent<ButtonSelect>().ButtonOff();

                GameObject.Find("Kinect").GetComponent<ButtonSelect>().ButtonOff();
 
                GameObject.Find("NBB").GetComponent<ButtonSelect>().ButtonOff();

            }
        }
    }
}
