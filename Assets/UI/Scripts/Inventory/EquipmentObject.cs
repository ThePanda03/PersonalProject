using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//creates prefab in the 3d Obj menu 
[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory system/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    //sets the Item type for the specific obj
    private void Awake()
    {
        itemType = Itemtype.Equipment;
    }
}
