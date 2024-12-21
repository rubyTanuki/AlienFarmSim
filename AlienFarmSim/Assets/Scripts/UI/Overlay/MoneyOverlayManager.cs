using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyOverlayManager : MonoBehaviour
{
    public TextMeshProUGUI numText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateMoneyText();
    }


    public void updateMoneyText(){
        int currentMoney = inventory.getMoney();
        if(Int32.Parse(numText.text) != currentMoney){
            string str = "" + currentMoney;
            while(str.Length<7){
                str = "0" + str;
            }
            numText.SetText(str);
        }
    }
}
