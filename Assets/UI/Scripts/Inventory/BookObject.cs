using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Timeline.Actions;
using UnityEngine;
//creates prefab in the 3d Obj menu 
[CreateAssetMenu(fileName = "New Book Object", menuName = "Inventory system/Items/Book")]
public class BookObject : ItemObject
{
    //sets item type for the prefab
    public void Awake()
    {
        itemType = Itemtype.Book;
    }
}
