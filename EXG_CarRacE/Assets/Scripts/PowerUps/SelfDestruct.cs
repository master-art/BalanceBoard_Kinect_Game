using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float initialTime = 0;

    public float waitTime = 10f;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (gameObject.active == true)
        {
            initialTime += Time.deltaTime;
            if (initialTime >= waitTime)
            {
                Destroy(gameObject);
            }
        }
       
    }
}
