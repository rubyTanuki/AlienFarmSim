using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIPSSlot : MonoBehaviour
{
    public PlantSO plant;
    public GameObject selected;
    private UIPRManager manager;
    private bool select;
    public GameObject image;
    public TextMeshProUGUI count;
    // Start is called before the first frame update
    void Start()
    {
        manager = this.gameObject.transform.parent.parent.parent.parent.parent.gameObject.GetComponent<UIPRManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bool leftClick = Input.GetMouseButtonDown(0);
        if(selected.activeSelf && leftClick){
            manager.Plant(plant);
        }

        selected.SetActive(select);
        select = false;
        if(inventory.seedInventory.ContainsKey(plant) && Int32.Parse(count.text)!=inventory.seedInventory[plant]){
            updateCountText();
        }
    }

    public void updateCountText(){
        string text = "" + inventory.seedInventory[plant];
        while(text.Length<3) text = "0" + text;
        count.SetText(text);
    }

    public void setSelected(bool s){
        select = s;
    }

    public void updateImage(){
        image.GetComponent<Image>().sprite = plant.sprites[4];
    }

    public void setPlant(PlantSO p){
        plant = p;
    }
}
