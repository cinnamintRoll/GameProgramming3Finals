using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpScript : MonoBehaviour
{
    public TextMeshProUGUI healthCounter, coinsCounter;

    public int coinCounter;
    public int healthPoints;

    // Update is called once per frame
    void Update()
    {
        healthCounter.text = healthPoints.ToString();
        coinsCounter.text = coinCounter.ToString();
    }
}
