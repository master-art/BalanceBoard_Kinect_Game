using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    //public Transform mHandMesh;
    GameObject HandMesh;
 

    private void Start()
    {
        HandMesh = GameObject.Find("HandRight");
    }

    // Update is called once per frame
    void Update()
    {
       // HandMesh.transform.position = Vector3.Lerp(HandMesh.transform.position, transform.position, Time.deltaTime * 15.0f);
        RaycastSingle();
    }

    private void RaycastSingle()
    {
        Vector3 origin = HandMesh.transform.position;
        Vector3 direction = HandMesh.transform.forward;

        Debug.DrawRay(origin, direction * 100f, Color.red);
        Ray ray = new Ray(origin, direction);

        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {

                if (raycastHit.collider.name == "Play")
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
                GameObject.Find("Play").GetComponent<ButtonSelect>().ButtonOff();

                GameObject.Find("Kinect").GetComponent<ButtonSelect>().ButtonOff();
 
                GameObject.Find("NBB").GetComponent<ButtonSelect>().ButtonOff();

            }
        }
        Debug.Log("UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject():" + "" + UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject());
    }
}
