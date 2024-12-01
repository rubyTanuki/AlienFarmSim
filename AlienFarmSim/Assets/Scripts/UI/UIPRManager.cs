using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPRManager : MonoBehaviour
{
    public List<UIPRSlot> currentSelected;
    public PlantSO selectedPlant;
    public GameObject plantSelector;
    public List<GameObject> rows;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.H)){
            harvestSelected();
        }

        if(currentSelected.Count>0)
            plantSelector.SetActive(true);
        else
            plantSelector.SetActive(false);
    }

    public void clearSelected(){
        plantSelector.SetActive(false);
        foreach (UIPRSlot slot in currentSelected){
            slot.selected.SetActive(false);
        }
        currentSelected.Clear();
    }

    public void Plant(PlantSO p){
        foreach (UIPRSlot slot in currentSelected){
            slot.plant.setPlant(p);
            slot.plant.resetPlant();
        }
        clearSelected();
    }

    void OnEnable(){
        clearSelected();
    }
    void OnDisable(){
        clearSelected();
    }

    public void harvestSelected(){
        foreach(UIPRSlot slot in currentSelected){
            slot.harvest();
        }
    }
    public void harvestAll(){
        foreach(GameObject row in rows){
            row.GetComponent<UIPRRow>().harvestAll();
        }
        clearSelected();
    }
}
