using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISellMarket : UIMarket
{

    private int numToSell;
    [SerializeField] private TextMeshProUGUI numToSellText;

    private Dictionary<ItemSO, int> sellableItems = new Dictionary<ItemSO, int>();
    
    void OnEnable(){
        populateSelectors();
        updateSelected();
    }

    void Update(){
        if(selectedItem != null){
            manager.covered = false;
        }

        if(selectedItem!=null && numToSell>sellableItems[selectedItem]){
            numToSell = sellableItems[selectedItem];
            updateNumToSell();
        }else if(selectedItem!=null && numToSell<0){
            numToSell = 0;
            updateNumToSell();
        }
        updateSelected();
    }


    public void populateSelectors(){
        updateMarket();
        for(int i=0;i<marketContent.transform.childCount;i++){
            Destroy(marketContent.transform.GetChild(i).gameObject);
        }
        foreach(KeyValuePair<ItemSO, int> kvp in sellableItems){
            instantiateSelectorSlot(kvp.Key, kvp.Value);
        }
    }

    private void instantiateSelectorSlot(ItemSO item, int num){
        GameObject selector = Instantiate(selectorPrefab);
        selector.transform.SetParent(marketContent.transform);
        selector.transform.localScale = new Vector3(1,1,1);
        UIMarketSelectorSlot script = selector.GetComponent<UIMarketSelectorSlot>();
        script.setItem(item);
        script.setNumInInv(num);
        script.setPrice((int)(item.baseValue*GameManager.ITEM_BUY_MULTIPLIER));
        script.updateInfo();
    }

    public void sellItem(){
        sellItem(selectedItem, numToSell);
    }
    public void sellItem(ItemSO item, int i){
        inventory.addMoney(selectedItem.baseValue*numToSell);
        if(selectedItem is PlantSO p){
            inventory.subFromInventory(p, numToSell);
            if(!inventory.containsItem(p))selectedItem = null;
        }else if(selectedItem is CropSO c){
            inventory.subFromInventory(c, numToSell);
            if(!inventory.containsItem(c))selectedItem = null;
        }else{
            inventory.subFromInventory(item, numToSell);
            if(!inventory.containsItem(item))selectedItem = null;
        }
        populateSelectors();
        updateSelected();
    }

    public void updateSelected(){
        if(selectedItem!=null && marketContains(selectedItem)){
            selectedName.SetText(selectedItem.name);
            RectTransform rt = selectedName.gameObject.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3(0, rt.anchoredPosition.y, 0);
            selectedDescription.SetText(selectedItem.description);
            int count = sellableItems[selectedItem];
            string countString = "" + count;
            while(countString.Length<3) countString = "0"+countString;
            selectedCount.SetText(countString);
        }
    }

    public bool marketContains(ItemSO item){
        return sellableItems.ContainsKey(item);
    }

    public void increaseNumToSell(){
        if(numToSell<sellableItems[selectedItem]){
            if(Input.GetKey(KeyCode.LeftControl)){
                numToSell = sellableItems[selectedItem];
            } 
            else ++numToSell;
        }
        updateNumToSell();
    }

    public void decreaseNumToSell(){
        if(numToSell>0){
            if(Input.GetKey(KeyCode.LeftControl)){
                numToSell = 0;
            }
            else --numToSell;
        }
        updateNumToSell();
    }

    public void updateNumToSell(){
        string str = "" + numToSell;
        while(str.Length<3) str = "0" + str;
        numToSellText.SetText(str);
    }

    public void updateMarket(){
        sellableItems.Clear();
        foreach(KeyValuePair<PlantSO, int> kvp in inventory.seedInventory){
            sellableItems.Add((ItemSO)kvp.Key, kvp.Value);
        }
        foreach(KeyValuePair<CropSO, int> kvp in inventory.cropInventory){
            sellableItems.Add((ItemSO)kvp.Key, kvp.Value);
        }
        foreach(KeyValuePair<ItemSO, int> kvp in inventory.itemInventory){
            sellableItems.Add(kvp.Key, kvp.Value);
        }
    }
}
