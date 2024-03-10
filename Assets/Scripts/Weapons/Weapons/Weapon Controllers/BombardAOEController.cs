using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardAOEController : WeaponController
{ 
    private Inventory playerInventory;
    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

    }

    protected override void Attack()
    {
        int itemIDToCheck = 11; // Replace 123 with the actual item ID you want to check
        bool itemExists = playerInventory.CheckItem(itemIDToCheck);

        if (itemExists)
        {
            base.Attack();
            GameObject spawnedBombardAOE = Instantiate(prefab);
            spawnedBombardAOE.transform.position = transform.position;

        }
    }
}