using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalController : WeaponController
{
    private Inventory playerInventory;

    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    protected override void Attack()
    {
        int itemIDToCheck = 6;
        bool itemExists = playerInventory.CheckItem(itemIDToCheck);

        if (itemExists)
        {
            base.Attack();
            SpawnBullet(1, 1); 
            SpawnBullet(-1, 1); 
            SpawnBullet(1, -1); 
            SpawnBullet(-1, -1);
        }
    }
    void SpawnBullet(float xDir, float yDir)
    {
        GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = new Vector2(xDir, yDir).normalized;
            rb.velocity = direction * speed;
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
