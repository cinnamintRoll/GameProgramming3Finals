using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour
{
    public HealthSystem healthSystem;
    public Inventory playerInventory;

    public float amount;

    private int previousItem20Quantity;

    public void Start()
    {
        if (playerInventory.inventory.ContainsKey(20))
        {
            previousItem20Quantity = playerInventory.inventory[20].quantity;
        }
        else
        {
            previousItem20Quantity = 0;
        }
    }

    public void Update()
    {
        CheckItem20Quantity();
    }


    private void CheckItem20Quantity()
    {
        if (playerInventory.inventory.ContainsKey(20))
        {
            int currentItem20Quantity = playerInventory.inventory[20].quantity;
            healthSystem.Heal(amount);

            if (currentItem20Quantity > previousItem20Quantity)
            {
                previousItem20Quantity = currentItem20Quantity;
            }
        }
    }
}
