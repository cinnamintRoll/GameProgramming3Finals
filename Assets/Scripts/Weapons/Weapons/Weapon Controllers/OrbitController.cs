using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : WeaponController
{
    private Inventory playerInventory;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

    }
    protected override void Attack()
    {
        int itemIDToCheck = 5; // Replace 123 with the actual item ID you want to check
        bool itemExists = playerInventory.CheckItem(itemIDToCheck);

        if (itemExists)
        {
            base.Attack();
            GameObject spawnedOrbit = Instantiate(prefab);
            spawnedOrbit.transform.position = transform.position;

        }
    }
}
