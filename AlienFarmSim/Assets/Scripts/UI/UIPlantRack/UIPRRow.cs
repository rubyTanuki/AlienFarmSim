using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPRRow : MonoBehaviour
{
    public List<UIPRSlot> slots;
    public UIPRManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonPushed(){
        bool selected = true;
        foreach (UIPRSlot slot in slots){
            if(!manager.currentSelected.Contains(slot)) selected = false;
        }
        if(selected) singleDeselectRow();
        else compoundSelectRow();
    }
    public void singleSelectRow(){
        manager.clearSelected();
        foreach (UIPRSlot slot in slots){
            //slot.Select();
        }
    }
    public void compoundSelectRow(){
        foreach (UIPRSlot slot in slots){
            //slot.Select();
        }
    }
    public void compoundDeselectRow(){
        manager.clearSelected();
    }
    public void singleDeselectRow(){
        foreach (UIPRSlot slot in slots){
            //slot.singleDeselect();
        }
    }

    public void harvestAll(){
        foreach(UIPRSlot slot in slots){
            // HarvestUpdateManager updateManager = GameObject.Find("UICanvas/HarvestUpdates").GetComponent<HarvestUpdateManager>();
            PlantSO h = slot.harvest();
            if(h!=null){
                // updateManager.addUpdate(h, 1);
                // if(slot.plant.growthStage == 4)
                //     updateManager.addUpdate(h.crop, h.baseYield);
            }
                
        }
    }

    IEnumerator wait(float seconds){
        yield return new WaitForSeconds(seconds);
    }


}
