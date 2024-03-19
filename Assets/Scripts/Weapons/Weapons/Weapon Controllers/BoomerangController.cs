using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : WeaponController
{
    private Inventory playerInventory;
    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    protected override void Attack()
    {
        int itemIDToCheck = 10; // Replace 123 with the actual item ID you want to check
        bool itemExists = playerInventory.CheckItem(itemIDToCheck);

        if (itemExists)
        {
            base.Attack();
            GameObject spawnedBoomerang = Instantiate(prefab);
            spawnedBoomerang.transform.position = transform.position;
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
