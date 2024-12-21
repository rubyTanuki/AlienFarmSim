using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Row Upgrade", menuName = "RowUpgradeSO")]
public class RowUpgradeSO : MonoBehaviour
{
    [SerializeField] protected string name;
    [SerializeField] protected string description;
    [SerializeField] protected int price;
    [SerializeField] protected Sprite icon;

    public string getName(){return name;}
    public string getDescription(){return description;}
    public int getPrice(){return price;}
    public Sprite getIcon(){return icon;}
}
