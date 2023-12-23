using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemtype
{
    Materials,
    Equipment,
    Book,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject Prefab;
    public Itemtype itemType;
    [TextArea(15,20)]
    public string Description;

}
