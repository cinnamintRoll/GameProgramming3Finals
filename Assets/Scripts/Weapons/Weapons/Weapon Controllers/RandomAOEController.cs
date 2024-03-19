using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAOEController : WeaponController
{
    private Transform enemy;
    private Inventory playerInventory;
    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

    }

    protected override void Attack()
    {
        int itemIDToCheck = 9; // Replace 123 with the actual item ID you want to check
        bool itemExists = playerInventory.CheckItem(itemIDToCheck);
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

        if (itemExists)
        {
            base.Attack();
            GameObject spawnedRandomAOE = Instantiate(prefab);
            spawnedRandomAOE.transform.position = enemy.transform.position;

        }
    }
    public void DMGIncrease(float amount)
    {
        damage += amount;
    }
    public void CooldownDecrease(float amount)
    {
        currentCooldown -= amount;
    }
    public void ProjectileSpeedUp(float amount)
    {
        speed += amount;
    }
}
