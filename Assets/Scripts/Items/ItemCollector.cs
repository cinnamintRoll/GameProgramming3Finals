using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{
    public Inventory playerInventory;

    public void CollectItem(Item item)
    {
        playerInventory.AddItem(item);
        // You might also want to remove the item from the game world
    }

    // You would typically call CollectItem when the player interacts with an item
}
