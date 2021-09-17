using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarHand : MonoBehaviour
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
        // HandMesh.transform.position = Vector3.Lerp(HandMesh.transform.position, transform.position, Time.deltaTime * 15.0f);
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

                if (raycastHit.collider.name == "Prev")
                {
                    Debug.Log("Inside Button RayCast Select" + raycastHit.collider.name);
                    raycastHit.collider.GetComponent<ButtonSelect>().ButtonOn();
                    raycastHit.collider.GetComponent<Image>().color = new Color(0.12f, 0.5f, 0.6f);
                }
                else if (raycastHit.collider.name == "Next")
                {
                    Debug.Log("Inside Button RayCast Select" + raycastHit.collider.name);
                    raycastHit.collider.GetComponent<ButtonSelect>().ButtonOn();
                    raycastHit.collider.GetComponent<Image>().color = new Color(0.12f, 0.5f, 0.6f);
                }

                else if (raycastHit.collider.name == "Confirm")
                {
                    Debug.Log("Inside Button RayCast Select" + raycastHit.collider.name);
                    raycastHit.collider.GetComponent<ButtonSelect>().ButtonOn();
                    raycastHit.collider.GetComponent<Image>().color = new Color(0.12f, 0.5f, 0.6f);
                }
            }
            else
            {
                GameObject.Find("Prev").GetComponent<ButtonSelect>().ButtonOff();

                GameObject.Find("Next").GetComponent<ButtonSelect>().ButtonOff();

                GameObject.Find("Confirm").GetComponent<ButtonSelect>().ButtonOff();

            }
        }
        Debug.Log("UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject():" + "" + UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject());
    }
}
