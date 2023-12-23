using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory system/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void addItem(ItemObject _item, int _amount)
    {
        bool HasItem = false;
        for (int i = 0; i < Container.Count; i++) 
        {
            if (Container[i].item == _item) 
            {
                Container[i].addAmount(_amount);
                HasItem = true;
                break;
            }
        }
        if(!HasItem) 
        { 
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
    
}
[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;

    }

    public void addAmount(int value)
    {
        amount += value;
    }
}
