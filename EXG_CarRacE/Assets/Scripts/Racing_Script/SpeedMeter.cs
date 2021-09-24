using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
    public PCarController SpeedPower;
    public GameObject needle;
    private float startPosition = 135f, endPosition = 225f;
    private float desiredPosition;

    public float carSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carSpeed = SpeedPower.curSpeed ;
        UpdateNeedle();
    }
   
    public void UpdateNeedle()
    {
        desiredPosition = endPosition - startPosition;
        float temp = carSpeed / 2010;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * desiredPosition));
    }
}
