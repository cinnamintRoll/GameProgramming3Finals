using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpScript : MonoBehaviour
{
    public TextMeshProUGUI healthCounter, coinsCounter;

    public float coinCounter;
    public float healthPoints;

    private PlayerHP healthSystem;

    void Start()
    {

        //Debug.Log("HpScript Start method called.");
        healthSystem = GetComponent<PlayerHP>();

        healthPoints = healthSystem.currentHP;

        
    }

    void Update()
    {
        // Subscribe to the OnPlayerHealthChanged event
        healthSystem.OnPlayerHealthChanged += UpdateHealthPoints;

        // Initialize UI with current health
        UpdateHealthPoints(healthSystem.currentHP, healthSystem.maxHP);

        healthCounter.text = healthPoints.ToString();
        coinsCounter.text = coinCounter.ToString();
    }

    void UpdateHealthPoints(float currentHP, float maxHP)
    {
        //Debug.Log("Updating Health Points. Current HP: " + currentHP + ", Max HP: " + maxHP);
        healthPoints = currentHP;
    }
}
