using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingController : WeaponController
{
    private Inventory playerInventory;
    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    protected override void Attack()
    {
        int itemIDToCheck = 2; // Replace 123 with the actual item ID you want to check
        bool itemExists = playerInventory.CheckItem(itemIDToCheck);

        if (itemExists)
        {
            base.Attack();
            GameObject spawnedHoming = Instantiate(prefab);
            spawnedHoming.transform.position = transform.position;
        }
    }
    public void DMGIncrease(float amount)
    {
        // Assuming 'damage' is a field representing player damage
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
