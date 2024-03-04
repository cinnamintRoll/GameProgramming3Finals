using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class SerializableKeyValuePair<TKey, TValue>
{
    public TKey Key;
    public TValue Value;

    public SerializableKeyValuePair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public Dictionary<int, Item> inventory = new Dictionary<int, Item>();

    [SerializeField]
    private List<SerializableKeyValuePair<int, Item>> inventoryList = new List<SerializableKeyValuePair<int, Item>>();

    private void SyncListWithDictionary()
    {
        inventoryList.Clear();
        foreach (var pair in inventory)
        {
            inventoryList.Add(new SerializableKeyValuePair<int, Item>(pair.Key, pair.Value));
        }
    }

    private void Update()
    {
        
    }
    public void AddItem(Item item)
    {
        // Check if the item already exists in the inventory
        if (inventory.ContainsKey(item.itemID))
        {
            // Update the item quantity or other properties
        }
        else
        {
            inventory.Add(item.itemID, item);
        }
        SyncListWithDictionary();
    }

    public bool RemoveItem(int itemID)
    {
        bool removed = inventory.Remove(itemID);
        if (removed)
        {
            SyncListWithDictionary(); // Update list after removing an item
        }
        return removed;
    }

    public bool CheckItem(int itemID)
    {
        return inventory.ContainsKey(itemID);

    }
    // Implement other necessary methods like GetItem, ListItems, etc.

}
