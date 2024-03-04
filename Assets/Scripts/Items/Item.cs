using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Item
{
    public string itemName;
    public int itemID;
    public int quantity;
    // Add other item properties like quantity, type, etc.

    public Item(string name, int id,int Quantity)
    {
        itemName = name;
        itemID = id;
        quantity = Quantity;
        // Initialize other properties
    }
}

