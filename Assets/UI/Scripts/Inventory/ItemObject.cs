using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Item list which is infintly exapndable 
public enum Itemtype
{
    Materials,
    Equipment,
    Book,
    Default
}
//Creates description box and sets item type for prefabs 
public abstract class ItemObject : ScriptableObject
{
    public GameObject Prefab;
    public Itemtype itemType;
    [TextArea(15,20)]
    public string Description;

}
