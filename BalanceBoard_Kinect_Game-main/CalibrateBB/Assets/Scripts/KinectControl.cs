using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectControl : MonoBehaviour
{
    public static Vector3 KinectInput;
    GameObject RHandMesh, LHandMesh;

    private void Start()
    {
        RHandMesh = GameObject.Find("HandRight");
        LHandMesh = GameObject.Find("HandLeft");
    }

    // Update is called once per frame
    void Update()
    {

        //For HandGesture
        RHandMesh.transform.position = new Vector3(RHandMesh.transform.position.x, 0, 0);

        Vector3 position = RHandMesh.transform.position;
        position.y = 0;
        position.x = RHandMesh.transform.position.x;
        position.z = 0;
        RHandMesh.transform.position = position;
        KinectInput = RHandMesh.transform.position;
        Debug.Log(KinectInput);
        LHandMesh.SetActive(false);
    }

}
