using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{

    public GameObject[] spawnObjects;

    public GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        SpawnStar();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnStar()
    {
        for(int i=0; i < spawnObjects.Length; i++)
        {
            spawnObjects[i] = Instantiate(star, spawnObjects[i].transform.position, spawnObjects[i].transform.rotation);
        }
    }
}
