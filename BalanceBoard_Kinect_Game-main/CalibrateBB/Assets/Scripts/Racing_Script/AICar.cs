using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour
{
    public GameObject theMarker;
    public GameObject[] mark;

    //public GameObject mark13;
    public int markTracker;

    // Update is called once per frame
    void Update()
    {
        if (markTracker == 0)
        {
            theMarker.transform.position = mark[0].transform.position;
        }
        if (markTracker == 1)
        {
            theMarker.transform.position = mark[1].transform.position;
        }
        if (markTracker == 2)
        {
            theMarker.transform.position = mark[2].transform.position;
        }
        if (markTracker == 3)
        {
            theMarker.transform.position = mark[3].transform.position;
        }
        if (markTracker == 4)
        {
            theMarker.transform.position = mark[4].transform.position;
        }
        if (markTracker == 5)
        {
            theMarker.transform.position = mark[5].transform.position;
        }
        if (markTracker == 6)
        {
            theMarker.transform.position = mark[6].transform.position;
        }
        if (markTracker == 7)
        {
            theMarker.transform.position = mark[7].transform.position;
        }
        if (markTracker == 8)
        {
            theMarker.transform.position = mark[8].transform.position;
        }
        if (markTracker == 9)
        {
            theMarker.transform.position = mark[9].transform.position;
        }
        if (markTracker == 10)
        {
            theMarker.transform.position = mark[10].transform.position;
        }
        if (markTracker == 11)
        {
            theMarker.transform.position = mark[11].transform.position;
        }
        if (markTracker == 12)
        {
            theMarker.transform.position = mark[12].transform.position;
        }
        if (markTracker == 13)
        {
            theMarker.transform.position = mark[13].transform.position;
        }
        if (markTracker == 14)
        {
            theMarker.transform.position = mark[14].transform.position;
        }
        if (markTracker == 15)
        {
            theMarker.transform.position = mark[15].transform.position;
        }
        if (markTracker == 16)
        {
            theMarker.transform.position = mark[16].transform.position;
        }
        if (markTracker == 17)
        {
            theMarker.transform.position = mark[17].transform.position;

        }
        if (markTracker == 18)
        {
            theMarker.transform.position = mark[18].transform.position;
        }
        if (markTracker == 19)
        {
            theMarker.transform.position = mark[19].transform.position;
        }
        if (markTracker == 20)
        {
            theMarker.transform.position = mark[20].transform.position;
        }
        if (markTracker == 21)
        {
            theMarker.transform.position = mark[21].transform.position;
        }
        if (markTracker == 22)
        {
            theMarker.transform.position = mark[22].transform.position;
        }
        if (markTracker == 23)
        {
            theMarker.transform.position = mark[23].transform.position;
        }
        if (markTracker == 24)
        {
            theMarker.transform.position = mark[24].transform.position;
        }
        if (markTracker == 25)
        {
            theMarker.transform.position = mark[25].transform.position;
        }
        if (markTracker == 26)
        {
            theMarker.transform.position = mark[26].transform.position;
        }
        if (markTracker == 27)
        {
            theMarker.transform.position = mark[27].transform.position;
        }

    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AICar")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            markTracker += 1;
            if (markTracker == mark.Length)
            {
                markTracker = 0;
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
