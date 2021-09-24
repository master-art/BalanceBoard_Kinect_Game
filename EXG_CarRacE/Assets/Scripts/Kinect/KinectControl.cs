using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectControl : MonoBehaviour
{
    public static Vector3 KinectInput;
    GameObject rHandMesh, lHandMesh, headMesh ;

    private void Start()
    {
        rHandMesh = GameObject.Find("HandRight");
        lHandMesh = GameObject.Find("HandLeft");
        headMesh = GameObject.Find("Head");
    }

    // Update is called once per frame
    void Update()
    {
        lHandMesh.SetActive(false);
        headMesh.SetActive(false);

        //For HandGesture
        rHandMesh.transform.position = new Vector3(rHandMesh.transform.position.x, 0, 0);

        //To restrict Right Hand movement only in x direction
        Vector3 position = rHandMesh.transform.position;
        position.y = 0;
        position.x = rHandMesh.transform.position.x;
        position.z = 0;
        rHandMesh.transform.position = position;
        KinectInput = rHandMesh.transform.position;
       // Debug.Log(KinectInput);
       
    }

}
