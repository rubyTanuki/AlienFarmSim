using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UIInvManager : MonoBehaviour
{
    public Dictionary<PlantSO, int> seedInventory = new Dictionary<PlantSO, int>();
    public Dictionary<CropSO, int> cropInventory = new Dictionary<CropSO, int>();
    public Dictionary<ItemSO, int> itemInventory = new Dictionary<ItemSO, int>();

    [SerializeField] private GameObject seedUI;
    [SerializeField] private GameObject cropUI;
    [SerializeField] private GameObject itemUI;

    public GameObject slotPrefab;

    public GameObject seedContent;
    public GameObject cropContent;
    public GameObject itemContent;

    public ItemSO selectedItem;

    [SerializeField] private TextMeshProUGUI moneyText;
    public int money;


    void OnEnable(){
        //remove previous selector slots
        for(int i=0;i<seedContent.transform.childCount;i++){
            Destroy(seedContent.transform.GetChild(i).gameObject);
        }
        for(int i=0;i<cropContent.transform.childCount;i++){
            Destroy(cropContent.transform.GetChild(i).gameObject);
        }
        for(int i=0;i<itemContent.transform.childCount;i++){
            Destroy(itemContent.transform.GetChild(i).gameObject);
        }
        
        

        //populate with updated slots
        populateSelectorSlots();
    }

    void Update(){
        updateMoneyText();
    }

    void updateMoneyText(){
        string s = "" + money;
        while(s.Length<7) s = "0" + s;
        if(Int32.Parse(moneyText.text) != money){
            moneyText.SetText(s);
        }
    }

    public void closeAll(){
        seedUI.SetActive(false);
        cropUI.SetActive(false);
        itemUI.SetActive(false);
    }
    public void openSeedUI(){
        closeAll();
        seedUI.SetActive(true);
    }
    public void openCropUI(){
        closeAll();
        cropUI.SetActive(true);
    }
    public void openItemUI(){
        closeAll();
        itemUI.SetActive(true);
    }
    public void populateSelectorSlots(){
        //populating seed inventory
        foreach(KeyValuePair<PlantSO, int> seed in seedInventory){
            addNewSelectorSlot(seed.Key, seed.Value, seedContent);
        }
        //populating crop inventory
        foreach(KeyValuePair<CropSO, int> crop in cropInventory){
            addNewSelectorSlot(crop.Key, crop.Value, cropContent);
        }
    }
    
    private void addNewSelectorSlot(ItemSO item, int c, GameObject content){
        GameObject slot = Instantiate(slotPrefab);
        UIInvSelectorSlot slotScript = slot.GetComponent<UIInvSelectorSlot>();
        slotScript.setItem(item);
        slotScript.setCount(c);
        slot.transform.SetParent(content.transform);
        slot.transform.localScale = new Vector3(1,1,1);
        slotScript.populateData();
    }
}
