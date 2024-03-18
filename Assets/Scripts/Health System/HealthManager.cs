using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text healthCount, healthMax;
    public Image healthBar;
    public float healthPoints;
    public float maxHealth;
    

    private PlayerHP healthSystem;

    void Start()
    {
        healthSystem = GetComponent<PlayerHP>();
        healthPoints = healthSystem.baseHP;
        maxHealth = healthSystem.maxHP;

        healthCount.text = healthPoints.ToString();
        healthMax.text = maxHealth.ToString();
        healthBar.fillAmount = healthPoints / maxHealth;
    }

    
    void Update()
    {
        /*if (healthAmount <=0)
        {

        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(20);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }*/

        healthSystem.OnPlayerHealthChanged += UpdateHealthInfo;

        healthCount.text = healthPoints.ToString();
        healthMax.text = maxHealth.ToString();

        healthBar.fillAmount = healthPoints / maxHealth;

    }

    void UpdateHealthInfo(float currentHP, float maxHP)
    {
        healthPoints = currentHP;
        maxHealth = maxHP;
    }

    /*public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }   */ 
}
