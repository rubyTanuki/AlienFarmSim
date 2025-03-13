using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemSO", menuName = "ItemSO")]
public class ItemSO : ScriptableObject
{
    public string extendedName;
    public string description;
    public Sprite image;
    public int baseValue;

    public string toString(){
        return extendedName;
    }
}
