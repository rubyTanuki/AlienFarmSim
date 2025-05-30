using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopSO", menuName = "ShopSO")]
public class ShopSO : ScriptableObject {
    

    public string shopName;
    public string owner;
    public string description;
    public Sprite sign;


    [Header("Listings")]
    [Space]
    public List<ItemSO> items = new List<ItemSO>();
    public List<int> cost = new List<int>();
    public List<int> amtInStock = new List<int>();
}
