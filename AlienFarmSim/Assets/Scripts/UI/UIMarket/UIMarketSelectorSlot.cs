using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMarketSelectorSlot : MonoBehaviour
{
    [SerializeField] private ItemSO item;
    private int numInInv;
    private int value;

    private UIMarket manager;
    
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private TextMeshProUGUI price;

    [SerializeField] private GameObject hover;
    private bool isHovering;
    private bool lastLeftClick = false;
   
    void OnEnable(){
        updateInfo();
    }
    void Start(){
        manager = this.gameObject.transform.parent.parent.parent.parent.gameObject.GetComponent<UIMarket>();
    }


    void Update(){
        bool leftClick = Input.GetMouseButtonDown(0);
        if(leftClick && hover.activeSelf){
            manager.selectedItem = item;
            manager.updateSelected();
        }
        hover.SetActive(isHovering);
        isHovering = false;
        lastLeftClick = leftClick;
    }
    public void setHover(bool b){ isHovering = b; }


    public void setItem(ItemSO i){
        item = i;
    }

    public void updateInfo(){
        if(item!=null){
            name.SetText(item.name);
            description.SetText(item.description);
            image.sprite = item.image;
            string zeros = "";
            if(numInInv<10) zeros = "00";
            else if(numInInv<100)zeros = "0";

            count.SetText(zeros + numInInv);

            if(value<10) zeros = "000";
            else if(value<100) zeros = "00";
            else if(value<1000) zeros = "0";
            price.SetText(zeros + value);
        }
    }
    public void setNumInInv(int n){
        numInInv = n;
    }
    public void setPrice(int v){
        value = v;
    }
}
