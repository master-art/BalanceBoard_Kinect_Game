using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPositionSystem : MonoBehaviour
{

    [Header("Cars")]
    [SerializeField] private Transform car1;
    [SerializeField] private Transform car2;

    [Header("Distance")]
    [SerializeField] private float car1Dis;
    [SerializeField] private float car2Dis;

    [Header("NextCheckPoint")]
    [SerializeField] private GameObject nextCheckPoint;

    [Header("Position")]
    public float First;
    public float Second;

    [Header("Text")]
    [SerializeField] private Text car1DispPos;
    [SerializeField] private Text car2DispPos;
   

    // Update is called once per frame
    void Update()
    {
        car1Dis = Vector3.Distance(transform.position, car1.position);
        car2Dis = Vector3.Distance(transform.position, car2.position);

        First = Mathf.Min(car1Dis, car2Dis);
        Second = Mathf.Max(car1Dis, car2Dis);

        if(car1Dis == First && car1Dis < car2Dis)
        {
            car1DispPos.text = "1";
            car2DispPos.text = "2";
        }
        else
        {
            car1DispPos.text = "2";
            car2DispPos.text = "1";
        }
         
    }

    private void OnTriggerEnter(Collider other)
    {
            gameObject.SetActive(false);
            nextCheckPoint.SetActive(true);
    }
}
