using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//creates prefab in the 3d Obj menu 
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory system/Inventory")]
public class InventoryObject : ScriptableObject
{
    //variable for the inventory slots
    public List<InventorySlot> Container = new List<InventorySlot>();
    //add the item to the list for the iventory system
    public void addItem(ItemObject _item, int _amount)
    {
        //makes sure the iventory knows you dont have the item 
        bool HasItem = false;

        //makes a container slot for the item and tells the inventory you have an item already 
        for (int i = 0; i < Container.Count; i++) 
        {
            if (Container[i].item == _item) 
            {
                Container[i].addAmount(_amount);
                HasItem = true;
                break;
            }
        }
        //adds a new container incase you already have a seperate item
        if(!HasItem) 
        { 
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
    
}
[System.Serializable]
public class InventorySlot
{
    //variable for the item obj
    public ItemObject item;
    //variable for the amount of the item you have 
    public int amount;

    //sets the inventory prefab for the slot 
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;

    }
    //add amount in the text obj
    public void addAmount(int value)
    {
        amount += value;
    }
}
