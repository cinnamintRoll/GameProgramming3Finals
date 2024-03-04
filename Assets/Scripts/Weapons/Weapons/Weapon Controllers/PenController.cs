using UnityEngine;

public class PenController : WeaponController
{
    private Inventory playerInventory;
    protected override void Start()
    {
        base.Start();
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        
    }

    protected override void Attack()
    {
        int itemIDToCheck = 3; // Replace 123 with the actual item ID you want to check
        bool itemExists = playerInventory.CheckItem(itemIDToCheck);

        if (itemExists)
        {
            base.Attack();
            GameObject spawnedPen = Instantiate(prefab);
            spawnedPen.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
            spawnedPen.GetComponent<PenBehaviour>().DirectionChecker(pm.lastMovedVector);   //Reference and set the direction}
        }
    }
}
