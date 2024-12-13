using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISellMarket : MonoBehaviour
{

    private int numToSell;
    [SerializeField] private TextMeshProUGUI numToSellText;

    private Dictionary<ItemSO, int> sellableItems = new Dictionary<ItemSO, int>();
    
    void OnEnable(){
        //populateSelectors();
        //updateSelected();
    }
}
