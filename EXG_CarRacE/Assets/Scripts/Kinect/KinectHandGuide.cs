using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectHandGuide : MonoBehaviour
{
    public GameObject handGuide;

    // Update is called once per frame
    void Update()
    {
        if (BodySourceView.isInstantiate)
        {
            handGuide.SetActive(false);
        }

    }
}
