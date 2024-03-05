using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWindow : MonoBehaviour
{
    Inventory playerInventory;
    public string itemName;
    public int itemID;
    public int quantity = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Weapon3()
    {
        Item itemToAdd = new Item(itemName, 3, quantity);
        playerInventory.AddItem(itemToAdd);
    }

    public void Weapon1()
    {
        Item itemToAdd = new Item(itemName, 1, quantity);
        playerInventory.AddItem(itemToAdd);
    }
}
