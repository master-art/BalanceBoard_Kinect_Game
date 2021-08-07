using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject halfPointtrigger;
    public GameObject lapCompleteTrigger;

    private void OnTriggerEnter()
    {
        lapCompleteTrigger.SetActive(true);
        halfPointtrigger.SetActive(false);
    }
}
