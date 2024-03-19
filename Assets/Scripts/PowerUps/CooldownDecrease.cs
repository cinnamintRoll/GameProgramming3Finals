using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownDecrease : MonoBehaviour
{
    public PenController penController;
    public Weapon1Controll meleeController;
    public HomingController homingController;
    public AOEController aoeController;
    public OrbitController orbitController;
    public DiagonalController diagonalController;
    public ThrowAOEController throwaoeController;
    public VerticalAOEController verticalaoeController;
    public BoomerangController boomerangController;
    public RandomAOEController randomaoeController;
    public BombardAOEController bombardaoeController;
    public FireController fireController;

    public Inventory playerInventory;

    public float amount;

    // Previous quantity of item 14 for comparison
    private int previousItem16Quantity;

    public void Start()
    {
        // Initialize previousItem14Quantity based on the current inventory state
        if (playerInventory.inventory.ContainsKey(16))
        {
            previousItem16Quantity = playerInventory.inventory[16].quantity;
        }
        else
        {
            previousItem16Quantity = 0;
        }
    }

    public void Update()
    {
        // Check for changes in item 14 quantity
        CheckItem16Quantity();
    }

    // Method to check for changes in item 14 quantity
    private void CheckItem16Quantity()
    {
        if (playerInventory.inventory.ContainsKey(16))
        {
            int currentItem16Quantity = playerInventory.inventory[16].quantity;

            // Check if the current quantity of item 14 is greater than the previous quantity
            if (currentItem16Quantity > previousItem16Quantity)
            {
                // Trigger cooldown decrease for all controllers
                penController.CooldownDecrease(amount);
                meleeController.CooldownDecrease(amount);
                homingController.CooldownDecrease(amount);
                aoeController.CooldownDecrease(amount);
                orbitController.CooldownDecrease(amount);
                diagonalController.CooldownDecrease(amount);
                throwaoeController.CooldownDecrease(amount);
                verticalaoeController.CooldownDecrease(amount);
                boomerangController.CooldownDecrease(amount);
                randomaoeController.CooldownDecrease(amount);
                bombardaoeController.CooldownDecrease(amount);
                fireController.CooldownDecrease(amount);

                // Update the previous quantity of item 14 to the current quantity
                previousItem16Quantity = currentItem16Quantity;
            }
        }
    }
}
