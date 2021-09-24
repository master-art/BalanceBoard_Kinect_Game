using UnityEngine;
using System.Collections;

public class DisableOnStart : MonoBehaviour {

    // Use this for initialization
    void Start () 
    {

        if (BodySourceView.isInstantiate)
        {
            gameObject.SetActive(false);
            BodySourceView.isInstantiate = false;
        }
        
    }
}
