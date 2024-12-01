using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemSO", menuName = "ItemSO")]
public class ItemSO : ScriptableObject
{
    public string name;
    public string shortName;
    public string description;

    public Sprite image;
}
