using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for all weapon controllers
/// </summary>
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    float originalCooldownDuration;
    public int pierce;

    protected PlayerMovement pm;


    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = cooldownDuration; //At the start set the current cooldown to be cooldown duration
        originalCooldownDuration = currentCooldown;
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)   //Once the cooldown becomes 0, attack
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }

    public void CooldownDebuff(float amount)
    {
        cooldownDuration += amount;
        currentCooldown = cooldownDuration;
    }

    public void ResetCooldown()
    {
        cooldownDuration = originalCooldownDuration;
        //Debug.Log("Cooldown reset to original: " + originalCooldownDuration);
    }
}
