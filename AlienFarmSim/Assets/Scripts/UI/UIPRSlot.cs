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
            inventory.addToInventory(h);

            if(plant.growthStage == 4){
                inventory.addToInventory(h.crop, h.baseYield);
                inventory.addToInventory(h);
            }
            
            plant.plant = null;
            manager.updateSelectors();
        }
        return h;
    }

}
