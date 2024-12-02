using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPRSlot : MonoBehaviour
{
    
    public GameObject hover;
    public GameObject selected;
    public UIPRManager manager;
    public UIPRPlant plant;
    private HarvestUpdateManager updates;

    private Sprite empty;

    public bool isHovering = false;

    private bool lastLeftClick = false;
    // Start is called before the first frame update
    void Start()
    {
        updates = GameObject.Find("UICanvas/HarvestUpdates").GetComponent<HarvestUpdateManager>();
        empty = plant.getImage();
    }

    // Update is called once per frame
    void Update()
    {
        bool leftClick = Input.GetMouseButtonDown(0);
        bool rightClick = Input.GetMouseButtonDown(1);

        if(hover.activeSelf){
            if(rightClick)
            {
                if(selected.activeSelf) singleDeselect();
                else Select();
            }
            if(leftClick)
            {
                if(selected.activeSelf) Deselect();
                else singleSelect();
            }
        }
        lastLeftClick = leftClick;
        hover.SetActive(isHovering);
        isHovering = false;
    }




    public void setHover(bool b){ isHovering = b; }

    public void Select(){
        selected.SetActive(true);
        manager.currentSelected.Add(this);
    }
    public void singleSelect(){
        selected.SetActive(true);
        if(manager.currentSelected != null && !manager.currentSelected.Contains(this))
            manager.clearSelected();
        manager.currentSelected.Add(this);
    }
    public void Deselect(){
        selected.SetActive(false);
        manager.clearSelected();
    }
    public void singleDeselect(){
        selected.SetActive(false);
        manager.currentSelected.Remove(this);
    }

    void OnEnable(){
        lastLeftClick = true;
        singleDeselect();
    }

    void OnDisable(){
        hover.SetActive(false);
    }

    public PlantSO harvest(){
        PlantSO h = plant.plant;
        if(h != null){
            if(manager.invManager.seedInventory.ContainsKey(h)){
                manager.invManager.seedInventory[h]++;
            }else{
                manager.invManager.seedInventory.Add(h, 1);
            }

            if(plant.growthStage == 4){
                if(manager.invManager.cropInventory.ContainsKey(h.crop)){
                    manager.invManager.cropInventory[h.crop] += h.baseYield;
                }else{
                    manager.invManager.cropInventory.Add(h.crop, h.baseYield);
                }
            }
            
            plant.plant = null;
        }
        return h;
    }

}
