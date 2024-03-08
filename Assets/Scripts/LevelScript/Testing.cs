using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Testing : MonoBehaviour
{
    Inventory playerInventory;
    public string itemName;
    public int itemID;
    public int quantity = 1;
    [SerializeField] private LevelWindow levelWindow;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        ExperienceSystem experienceSystem = new ExperienceSystem();
        levelWindow.SetExperienceSystem(experienceSystem);
    }

    public void Weapon12()
    {
        Item itemToAdd = new Item(itemName, 12, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon11()
    {
        Item itemToAdd = new Item(itemName, 11, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon10()
    {
        Item itemToAdd = new Item(itemName, 10, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon9()
    {
        Item itemToAdd = new Item(itemName, 9, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon8()
    {
        Item itemToAdd = new Item(itemName, 8, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon7()
    {
        Item itemToAdd = new Item(itemName, 7, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon6()
    {
        Item itemToAdd = new Item(itemName, 6, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon5()
    {
        Item itemToAdd = new Item(itemName, 5, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon4()
    {
        Item itemToAdd = new Item(itemName, 4, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon3()
    {
        Item itemToAdd = new Item(itemName, 3, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon2()
    {
        Item itemToAdd = new Item(itemName, 2, quantity);
        playerInventory.AddItem(itemToAdd);
    }
    public void Weapon1()
    {
        Item itemToAdd = new Item(itemName, 1, quantity);
        playerInventory.AddItem(itemToAdd);
    }
}
