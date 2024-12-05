using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMarketSelectorSlot : MonoBehaviour
{
    [SerializeField] private ItemSO item;
    private int numInInv;
    
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private TextMeshProUGUI price;

    [SerializeField] private GameObject hover;
    private bool isHovering;

    void OnEnable(){
        if(item != null){
            name.SetText(item.name);
            description.SetText(item.description);
            image.sprite = item.image;
            count.SetText("" + numInInv);
            price.SetText(" " + "TBD");
        }
    }

    void Update(){
        hover.SetActive(isHovering);
        isHovering = false;
    }
    public void setHover(bool b){ isHovering = b; }


    public void setItem(ItemSO i){
        item = i;
    }
    public void setNumInInv(int n){
        numInInv = n;
    }
}
