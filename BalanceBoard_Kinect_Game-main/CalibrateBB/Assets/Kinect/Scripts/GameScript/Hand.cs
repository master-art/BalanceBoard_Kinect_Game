using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    //public Transform mHandMesh;
    GameObject RHandMesh, LHandMesh;

    private void Start()
    {
        RHandMesh = GameObject.Find("HandRight");
        LHandMesh = GameObject.Find("HandLeft");
    }
   
    // Update is called once per frame
    void Update()   
    {
        //RHandMesh.transform.position = Vector3.Lerp(RHandMesh.transform.position, transform.position, Time.deltaTime * 15.0f);
        LHandMesh.SetActive(false);
        RaycastSingle();
    }

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
                    Debug.Log("Inside Button RayCast Select" + raycastHit.collider.name);
                    raycastHit.collider.GetComponent<ButtonSelect>().ButtonOn();
                    raycastHit.collider.GetComponent<Image>().color = new Color(0.12f, 0.5f, 0.6f);
                }
                else if (raycastHit.collider.name == "Kinect")
                {
                    Debug.Log("Inside Button RayCast Select" + raycastHit.collider.name);
                    raycastHit.collider.GetComponent<ButtonSelect>().ButtonOn();
                    raycastHit.collider.GetComponent<Image>().color = new Color(0.12f, 0.5f, 0.6f);
                }

                else if(raycastHit.collider.name == "NBB")
                {
                    Debug.Log("Inside Button RayCast Select" + raycastHit.collider.name);
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
        Debug.Log("UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject():" + "" + UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject());
    }
}
