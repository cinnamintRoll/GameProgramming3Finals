using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUp : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Inventory playerInventory;

    public float amount;
    // Start is called before the first frame update
    private int previousItem18Quantity;

    public void Start()
    {
        // Initialize previousItem14Quantity based on the current inventory state
        if (playerInventory.inventory.ContainsKey(18))
        {
            previousItem18Quantity = playerInventory.inventory[18].quantity;
        }
        else
        {
            previousItem18Quantity = 0;
        }
    }

    public void Update()
    {
        // Check for changes in item 14 quantity
        CheckItem18Quantity();
    }

    // Method to check for changes in item 14 quantity
    private void CheckItem18Quantity()
    {
        if (playerInventory.inventory.ContainsKey(18))
        {
            int currentItem18Quantity = playerInventory.inventory[18].quantity;

            // Check if the current quantity of item 14 is greater than the previous quantity
            if (currentItem18Quantity > previousItem18Quantity)
            {
               
                playerMovement.PlayerSpeedUp(amount);

                previousItem18Quantity = currentItem18Quantity;
            }
        }
    }
}
