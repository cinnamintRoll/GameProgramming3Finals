using UnityEngine;

public class BarrierController : WeaponController
{
    private Inventory playerInventory;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        int itemIDToCheck = 15; // Replace 123 with the actual item ID you want to check
        bool itemExists = playerInventory.CheckItem(itemIDToCheck);

        if (itemExists)
        {
            base.Attack();
            GameObject spawnedBarrier = Instantiate(prefab);
            spawnedBarrier.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
            spawnedBarrier.transform.parent = transform;
        }
        
    }
}