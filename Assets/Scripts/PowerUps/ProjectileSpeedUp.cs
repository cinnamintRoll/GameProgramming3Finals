using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpeedUp : MonoBehaviour
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
    private int previousItem17Quantity;

    public void Start()
    {
        // Initialize previousItem14Quantity based on the current inventory state
        if (playerInventory.inventory.ContainsKey(17))
        {
            previousItem17Quantity = playerInventory.inventory[17].quantity;
        }
        else
        {
            previousItem17Quantity = 0;
        }
    }

    public void Update()
    {
        // Check for changes in item 14 quantity
        CheckItem17Quantity();
    }

    // Method to check for changes in item 14 quantity
    private void CheckItem17Quantity()
    {
        if (playerInventory.inventory.ContainsKey(17))
        {
            int currentItem17Quantity = playerInventory.inventory[17].quantity;

            // Check if the current quantity of item 14 is greater than the previous quantity
            if (currentItem17Quantity > previousItem17Quantity)
            {
                // Trigger cooldown decrease for all controllers
                penController.ProjectileSpeedUp(amount);
                meleeController.ProjectileSpeedUp(amount);
                homingController.ProjectileSpeedUp(amount);
                aoeController.ProjectileSpeedUp(amount);
                orbitController.ProjectileSpeedUp(amount);
                diagonalController.ProjectileSpeedUp(amount);
                throwaoeController.ProjectileSpeedUp(amount);
                verticalaoeController.ProjectileSpeedUp(amount);
                boomerangController.ProjectileSpeedUp(amount);
                randomaoeController.ProjectileSpeedUp(amount);
                bombardaoeController.ProjectileSpeedUp(amount);
                fireController.ProjectileSpeedUp(amount);

                // Update the previous quantity of item 14 to the current quantity
                previousItem17Quantity = currentItem17Quantity;
            }
        }
    }
}
