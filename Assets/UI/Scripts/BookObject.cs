using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Timeline.Actions;
using UnityEngine;
[CreateAssetMenu(fileName = "New Book Object", menuName = "Inventory system/Items/Book")]
public class BookObject : ItemObject
{
    public void Awake()
    {
        itemType = Itemtype.Book;
    }
}
