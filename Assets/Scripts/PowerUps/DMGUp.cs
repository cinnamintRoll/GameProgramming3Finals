using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGUp : MonoBehaviour
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
    private int previousItem14Quantity;

    public void Start()
    {
        // Initialize previousItem14Quantity based on the current inventory state
        if (playerInventory.inventory.ContainsKey(14))
        {
            previousItem14Quantity = playerInventory.inventory[14].quantity;
        }
        else
        {
            previousItem14Quantity = 0;
        }
    }

    public void Update()
    {
        // Check for changes in item 14 quantity
        CheckItem14Quantity();
    }

    // Method to check for changes in item 14 quantity
    private void CheckItem14Quantity()
    {
        if (playerInventory.inventory.ContainsKey(14))
        {
            int currentItem14Quantity = playerInventory.inventory[14].quantity;

            // Check if the current quantity of item 14 is greater than the previous quantity
            if (currentItem14Quantity > previousItem14Quantity)
            {
                // Trigger cooldown decrease for all controllers
                penController.DMGIncrease(amount);
                meleeController.DMGIncrease(amount);
                homingController.DMGIncrease(amount);
                aoeController.DMGIncrease(amount);
                orbitController.DMGIncrease(amount);
                diagonalController.DMGIncrease(amount);
                throwaoeController.DMGIncrease(amount);
                verticalaoeController.DMGIncrease(amount);
                boomerangController.DMGIncrease(amount);
                randomaoeController.DMGIncrease(amount);
                bombardaoeController.DMGIncrease(amount);
                fireController.DMGIncrease(amount);

                // Update the previous quantity of item 14 to the current quantity
                previousItem14Quantity = currentItem14Quantity;
            }
        }
    }
}


