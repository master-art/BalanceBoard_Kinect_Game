using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{

    [SerializeField] private GameObject Pc;
    [SerializeField] private GameObject postionCheckHolder;

    [SerializeField] private GameObject [] cars;
    [SerializeField] private Transform [] positionCheckpoints;
    [SerializeField] private GameObject[] checkpointForEachCar;

    private int totalCars;
    private int totalCheckpoints;

    public Text[] positionTxt;




    // Start is called before the first frame update
    void Start()
    {
        totalCars = cars.Length;
        totalCheckpoints = postionCheckHolder.transform.childCount;

        setCheckpoints();
        setCarPostion();
    }
    
    //Method

    void setCheckpoints()
    {
        positionCheckpoints = new Transform[totalCheckpoints];

        for(int i =0; i< totalCheckpoints; i++ )
        {
           positionCheckpoints[i] = postionCheckHolder.transform.GetChild(i).transform;
          
        }

        checkpointForEachCar = new GameObject[totalCars];
        for (int i = 0; i < totalCars; i++)
        {
            checkpointForEachCar[i] = Instantiate(Pc, positionCheckpoints[0].position, positionCheckpoints[0].rotation);
            checkpointForEachCar[i].name = "PC" + i;
            checkpointForEachCar[i].layer = 9 + i;
        }
    }

    void setCarPostion()
    {
        for (int i = 0; i < totalCars; i++)
        {
            cars[i].GetComponent<CarPCManager>().carPosition = i + 1;
            cars[i].GetComponent<CarPCManager>().carNumber = i;
        }
    }
    public void CarCollectedPc(int carNumber, int cpNumber)
    {
        checkpointForEachCar[carNumber].transform.position = positionCheckpoints[cpNumber].transform.position;
        checkpointForEachCar[carNumber].transform.rotation = positionCheckpoints[cpNumber].transform.rotation;
        comparePosition(carNumber);
    }

    void comparePosition(int carNumber)
    {
        if(cars[carNumber].GetComponent<CarPCManager>().carPosition > 1)
        {
            GameObject currentCar = cars[carNumber];
            int currentCarPos = currentCar.GetComponent<CarPCManager>().carPosition;
            int currentCarPC = currentCar.GetComponent<CarPCManager>().pcCrossed;

            GameObject carInFront = null;
            int carInFrontPos = 0;
            int carInFrontPC = 0;

            for (int i = 0; i < totalCars; i++){

                if(cars[i].GetComponent<CarPCManager>().carPosition == currentCarPos - 1)
                {
                    carInFront = cars[i];
                    carInFrontPC = carInFront.GetComponent<CarPCManager>().pcCrossed;
                    carInFrontPos = carInFront.GetComponent<CarPCManager>().carPosition;
                    break;
                }
            }

            if(currentCarPC > carInFrontPC)
            {
                currentCar.GetComponent<CarPCManager>().carPosition = currentCarPos - 1;
                carInFront.GetComponent<CarPCManager>().carPosition = carInFrontPos + 1;

                Debug.Log("Car" + carNumber + "Has over taken" + carInFront.GetComponent<CarPCManager>().carNumber);
            }

            positionTxt[0].text = cars[0].GetComponent<CarPCManager>().carPosition.ToString();
            positionTxt[1].text = cars[1].GetComponent<CarPCManager>().carPosition.ToString();
            Debug.Log("Normal car Position" + positionTxt[0].text);
        }
    }
}
