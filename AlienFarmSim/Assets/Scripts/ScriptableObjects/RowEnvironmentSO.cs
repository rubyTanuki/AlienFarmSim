using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Row Environment", menuName = "RowEnvironmentSO")]
public class RowEnvironmentSO : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int price;
    [SerializeField] private Sprite background;
    [SerializeField] private Sprite icon;


    public string getName(){return name;}
    public string getDescription(){return description;}
    public int getPrice(){return price;}
    public Sprite getBackground(){return background;}
    public Sprite getIcon(){return icon;}
}
