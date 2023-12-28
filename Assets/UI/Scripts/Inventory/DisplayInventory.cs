using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    //variable for the inventory obj prefab
    public InventoryObject inventory;
    //variables to tell where to start inventory boxes
    public int X_Start;
    public int Y_Start;
    //variables to tell how far apart inventory boxes should be 
    public int X_Space_between_Item;
    public int Y_Space_between_Item;
    //how many inventory boxes in a row 
    public int Number_Of_Collums;
    //gets the item from dictonary and display icon
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    //creates the display obj for inventory depending on what item prefab player picked up
    public void CreateDisplay()
    {
        for (int i = 0; i <inventory.Container.Count; i++) 
        { 
            var obj = Instantiate(inventory.Container[i].item.Prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }
    //Gets the position on where to place the display obj
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_Start +(X_Space_between_Item * (i % Number_Of_Collums)), Y_Start + ((-Y_Space_between_Item *(i/Number_Of_Collums))), 0f);
    }
    //Updates the Inventory display
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            //Updates the number of items on the Display obj 
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            //creates new display obj if a new type of item has been picked up
            else
            {
                var obj = Instantiate(inventory.Container[i].item.Prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
}
