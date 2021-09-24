using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerArcade : MonoBehaviour
{
    public GameObject player;
    public GameObject child;

    public float speed;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        child = player.transform.Find("camera constraint").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        follow();
    }

    private void follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(player.gameObject.transform.position);
    }
}
