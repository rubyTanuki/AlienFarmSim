using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UIMarketManager : MonoBehaviour
{
    [SerializeField] private GameObject selectorPrefab;
    [SerializeField] private GameObject seedSelectorContent;
    [SerializeField] private GameObject cropSelectorContent;
    [SerializeField] private GameObject itemSelectorContent;

    private GameObject seedListObject;
    private GameObject cropListObject;
    private GameObject itemListObject;
    [SerializeField] private GameObject invManager;
    private UIInvManager invManagerScript;

    public ItemSO selectedItem;

    [SerializeField] TextMeshProUGUI selectedName;
    [SerializeField] TextMeshProUGUI selectedCount;
    [SerializeField] TextMeshProUGUI selectedDescription;
    [SerializeField] GameObject cover;
    [SerializeField] TextMeshProUGUI numToSellText;
    private int numToSell;
    private int numOfItems;

    [SerializeField] TextMeshProUGUI moneyText;


    void Awake()
    {
        invManagerScript = invManager.GetComponent<UIInvManager>();
        seedListObject = seedSelectorContent.transform.parent.parent.parent.gameObject;
        cropListObject = cropSelectorContent.transform.parent.parent.parent.gameObject;
        itemListObject = itemSelectorContent.transform.parent.parent.parent.gameObject;
    }

    void OnEnable(){
        populateSelectors();
    }
    
    void Update(){
        cover.SetActive(selectedItem == null);

        if(numToSell>numOfItems){
            numToSell = numOfItems;
            updateNumToSell();
        }
        updateMoneyText();
    }

    void updateMoneyText(){
        if(Int32.Parse(moneyText.text) != inventory.getMoney()){
            string s = "" + inventory.getMoney();
            while(s.Length<7) s = "0" + s;
            moneyText.SetText(s);
        }
    }

    public void populateSelectors(){
        //destroy all outdated selector slots
        GameObject[] contents = {seedSelectorContent, cropSelectorContent, itemSelectorContent};
        foreach(GameObject content in contents){
            for(int i=0;i<content.transform.childCount;i++){
                Destroy(content.transform.GetChild(i).gameObject);
            }
        }

        //add all the plant objects
        foreach(KeyValuePair<PlantSO, int> kvp in inventory.seedInventory){
            instantiateSelectorSlot(kvp.Key, kvp.Value, seedSelectorContent);
        }

        //add all the crop objects
        foreach(KeyValuePair<CropSO, int> kvp in inventory.cropInventory){
            instantiateSelectorSlot(kvp.Key, kvp.Value, cropSelectorContent);
        }

        //add all the item objects
        foreach(KeyValuePair<ItemSO, int> kvp in inventory.itemInventory){
            instantiateSelectorSlot(kvp.Key, kvp.Value, itemSelectorContent);
        }
    }


    public void updateSelected(){
        if(selectedItem != null){
            selectedName.SetText(selectedItem.name);
            RectTransform rt = selectedName.gameObject.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3(0, rt.anchoredPosition.y, 0);
            selectedDescription.SetText(selectedItem.description);
            int count = 0;
            var type = selectedItem.GetType();
            if(type.Equals(typeof(PlantSO))){
                PlantSO p = (PlantSO)selectedItem;
                count = inventory.seedInventory[p];
                numOfItems = inventory.seedInventory[p];
            }else if(type.Equals(typeof(CropSO))){
                CropSO c = (CropSO)selectedItem;
                count = inventory.cropInventory[c];
                numOfItems = inventory.cropInventory[c];
            }

            string countString = "";
            if(count<10) countString = "00" + count;
            else if(count<100) countString = "0" + count;
            else countString = "" + count;
            selectedCount.SetText(countString);
        }
    }

    public void increaseNumToSell(){
        if(numToSell<numOfItems){
            if(Input.GetKey(KeyCode.LeftControl)){
                numToSell = numOfItems;
            } 
            else ++numToSell;
            numToSellText.SetText("" + numToSell);
        }
    }

    public void decreaseNumToSell(){
        if(numToSell>0){
            if(Input.GetKey(KeyCode.LeftControl)){
                numToSell = 0;
            }
            else --numToSell;
            numToSellText.SetText("" + numToSell);
        }
    }

    public void updateNumToSell(){
        numToSellText.SetText("" + numToSell);
    }

    private void instantiateSelectorSlot(ItemSO item, int num, GameObject content){
        GameObject selector = Instantiate(selectorPrefab);
        selector.transform.SetParent(content.transform);
        selector.transform.localScale = new Vector3(1,1,1);
        UIMarketSelectorSlot script = selector.GetComponent<UIMarketSelectorSlot>();
        script.setItem(item);
        script.setNumInInv(num);
        script.setPrice(item.baseValue);
        script.updateInfo();
    }


    public void closeAll(){
        seedListObject.SetActive(false);
        cropListObject.SetActive(false);
        itemListObject.SetActive(false);
    }

    public void openSeedContent(){
        closeAll();
        seedListObject.SetActive(true);
    }
    public void openCropContent(){
        closeAll();
        cropListObject.SetActive(true);
    }
    public void openItemContent(){
        closeAll();
        itemListObject.SetActive(true);
    }

    public void sellSelectedItem(){
        invManagerScript.money += selectedItem.baseValue*numToSell;
        if(inventory.containsItem(selectedItem)){
            inventory.subFromInventory(selectedItem, numToSell);
        }
        // if(!inventory.containsItem(selectedItem)){
        //     selectedItem = null;
        // }
        
        populateSelectors();
        updateSelected();
    }
}
