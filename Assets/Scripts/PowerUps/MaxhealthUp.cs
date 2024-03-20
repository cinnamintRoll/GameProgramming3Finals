using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxhealthUp : MonoBehaviour
{
    public HealthSystem healthSystem;
    public Inventory playerInventory;

    public float amount;

    private int previousItem19Quantity;

    public void Start()
    {
        if (playerInventory.inventory.ContainsKey(19))
        {
            previousItem19Quantity = playerInventory.inventory[19].quantity;
        }
        else
        {
            previousItem19Quantity = 0;
        }
    }

    public void Update()
    {
        CheckItem19Quantity();
    }


    private void CheckItem19Quantity()
    {
        if (playerInventory.inventory.ContainsKey(14))
        {
            int currentItem19Quantity = playerInventory.inventory[14].quantity;
            healthSystem.IncreaseMaxHP(amount);
            
            if (currentItem19Quantity > previousItem19Quantity)
            {  
                previousItem19Quantity = currentItem19Quantity;
            }
        }
    }
}
