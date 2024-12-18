using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPRSlot : MonoBehaviour
{
    
    public GameObject hover;
    public GameObject selected;
    //public UIPRManager manager;
    public UIPRPlant plant;
    private HarvestUpdateManager updates;
    private UIPRRowManager row;

    private Sprite empty;

    public bool isHovering = false;

    private bool lastLeftClick = false;

    private float timer;
    private bool allowedToClick;

    void OnEnable(){
        timer = Time.time;
        lastLeftClick = true;
        allowedToClick = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        updates = GameObject.Find("UICanvas/HarvestUpdates").GetComponent<HarvestUpdateManager>();
        empty = plant.getImage();
        row = transform.parent.gameObject.GetComponent<UIPRRowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bool leftClick = Input.GetMouseButton(0);
        bool rightClick = Input.GetMouseButtonDown(1);
        if(!leftClick){
            allowedToClick = true;
        }

        if(hover.activeSelf && Time.time-timer>.5f && allowedToClick){
            if(rightClick)
            {
                
            }
            if(leftClick)
            {
                harvest();
            }
        }
        lastLeftClick = leftClick;
        hover.SetActive(isHovering && row.interactable());
        isHovering = false;
    }




    public void setHover(bool b){ isHovering = b; }

    public void select(){
        
    }

    // public void Select(){
    //     selected.SetActive(true);
    //     manager.currentSelected.Add(this);
    // }
    // public void singleSelect(){
    //     selected.SetActive(true);
    //     if(manager.currentSelected != null && !manager.currentSelected.Contains(this))
    //         manager.clearSelected();
    //     manager.currentSelected.Add(this);
    // }
    // public void Deselect(){
    //     selected.SetActive(false);
    //     manager.clearSelected();
    // }
    // public void singleDeselect(){
    //     selected.SetActive(false);
    //     manager.currentSelected.Remove(this);
    // }

    void OnDisable(){
        hover.SetActive(false);
    }

    public PlantSO harvest(){
        PlantSO h = plant.plant;
        if(h != null){
            if(plant.growthStage == 4){
                inventory.addToInventory(h.crop, h.baseYield);
                //updates.addUpdate(h.crop, h.baseYield);
                inventory.addToInventory(h, 2);
                //updates.addUpdate(h, 2);
            }else{
                inventory.addToInventory(h);
                //updates.addUpdate(h, 1);
            }
            
            plant.plant = null;
            //manager.updateSelectors();
        }
        return h;
    }

    public void plantSeed(PlantSO p){
        harvest();
        plant.plant = p;
        plant.resetPlant();
    }

}
