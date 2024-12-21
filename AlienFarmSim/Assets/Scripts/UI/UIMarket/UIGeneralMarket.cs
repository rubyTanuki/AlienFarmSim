using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGeneralMarket : UIMarket
{

    private int numToBuy;
    [SerializeField] private TextMeshProUGUI numToBuyText;
    [SerializeField] private TextMeshProUGUI priceText;

    

    

    private Dictionary<ItemSO, int> buyableItems = new Dictionary<ItemSO, int>();


    void Awake(){
        PlantSO p = Resources.Load<PlantSO>("Items/testPlant2");
        buyableItems.Add(p, 10);
        FabricatorModuleSO r = Resources.Load<FabricatorModuleSO>("Items/FabricatorMod02");
        buyableItems.Add(r, 1);
    }
    

    void OnEnable(){
        
        populateSelectors();
        updateSelected();
    }

    void Start(){
        
    }

    void Update(){
        if(selectedItem != null){
            manager.covered = false;
        }
        updateSelected();
    }

    public void updateSelected(){
        if(selectedItem!=null && marketContains(selectedItem)){
            selectedName.SetText(selectedItem.name);
            RectTransform rt = selectedName.gameObject.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3(0, rt.anchoredPosition.y, 0);
            selectedDescription.SetText(selectedItem.description);
            int count = buyableItems[selectedItem];
            string countString = "" + count;
            while(countString.Length<3) countString = "0"+countString;
            selectedCount.SetText(countString);

            updatePrice();
        }
    }

    public void populateSelectors(){
        for(int i=0;i<marketContent.transform.childCount;i++){
            Destroy(marketContent.transform.GetChild(i).gameObject);
        }
        foreach(KeyValuePair<ItemSO, int> kvp in buyableItems){
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


    public void buyItem(){
        buyItem(selectedItem, numToBuy);
    }
    public void buyItem(ItemSO item, int i){
        int amountToBuy = i;
        int buyPrice = (int)(i*(item.baseValue*GameManager.ITEM_BUY_MULTIPLIER));
        if(inventory.getMoney()>buyPrice){
            if(marketContains(item)){
                if(i>buyableItems[item]) amountToBuy = buyableItems[item];
            }
            inventory.subMoney(buyPrice);

            if(item is PlantSO p){
                inventory.addToInventory(p, amountToBuy);
            }else if(item is CropSO c){
                inventory.addToInventory(c, amountToBuy);
            }else if(item is FabricatorModuleSO f){
                inventory.addFabricatorModule(f);
            }else{
                inventory.addToInventory(item, amountToBuy);
            }
            subItemFromMarket(item, amountToBuy);
            populateSelectors();
        }else{
            Debug.Log("Not Enough Money");
        }
        
    }

    public void subItemFromMarket(ItemSO item, int i){
        if(marketContains(item)){
            buyableItems[item]-=i;
            if(buyableItems[item] <=0){
                buyableItems.Remove(item);
                selectedItem = null;
            }
        }
    }

    public bool marketContains(ItemSO item){
        return buyableItems.ContainsKey(item);
    }

    public void increaseNumToBuy(){
        int numOfItems = buyableItems[selectedItem];
        if(numToBuy<numOfItems){
            if(Input.GetKey(KeyCode.LeftControl)){
                numToBuy = numOfItems;
            }
            else ++numToBuy;

            string numString = "" + numToBuy;
            while(numString.Length<3) numString = "0" + numString;
            numToBuyText.SetText(numString);

            updatePrice();
        }

    }
    public void decreaseNumToBuy(){
        int numOfItems = buyableItems[selectedItem];
        if(numToBuy>0){
            if(Input.GetKey(KeyCode.LeftControl)){
                numToBuy = 0;
            }
            else --numToBuy;

            string numString = "" + numToBuy;
            while(numString.Length<3) numString = "0" + numString;
            numToBuyText.SetText(numString);

            updatePrice();
        }

    }
    public void updatePrice(){
        string priceString = "" + (int)(numToBuy*(selectedItem.baseValue*GameManager.ITEM_BUY_MULTIPLIER));
        while(priceString.Length<4) priceString = "0" + priceString;
        priceText.SetText(priceString);
    }
}
