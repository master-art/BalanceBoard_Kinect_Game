using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinHandler : MonoBehaviour
{
    public int score = 0;

    public Text scoreView;

    // Update is called once per frame
    void Update()
    {
        scoreView.text = "" + score;
    }
}
