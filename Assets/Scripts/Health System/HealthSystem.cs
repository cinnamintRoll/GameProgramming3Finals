using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public float baseHP = 10;
    public float maxHP;
    public float currentHP;

    protected internal event Action<float, float> OnHealthChanged; // Event to notify when health changes

    protected virtual void Start()
    {
        maxHP = baseHP;
        currentHP = maxHP;
    }

    public virtual void Heal(float addHP)
    {
        currentHP += addHP;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if (OnHealthChanged != null) OnHealthChanged(currentHP, currentHP);
    }

    public virtual void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if (OnHealthChanged != null) OnHealthChanged.Invoke(currentHP, maxHP);
        if (currentHP <= 0) Die();
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        //Destroy(gameObject);
    }


    //Method incase of increase HP powerup
    public virtual void IncreaseMaxHP(float amount)
    {
        baseHP += amount;
        maxHP = baseHP;

        currentHP = Mathf.Min(currentHP, maxHP);

        if (OnHealthChanged != null) OnHealthChanged.Invoke(currentHP, maxHP);
    }
}


