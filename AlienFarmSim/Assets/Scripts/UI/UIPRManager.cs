using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPRManager : MonoBehaviour
{
    public List<UIPRSlot> currentSelected;
    public PlantSO selectedPlant;
    public GameObject plantSelector;
    public GameObject plantSelectorSlotPrefab;
    public List<GameObject> rows;

    public GameObject selectorContent;

    public UIInvManager invManager;

    void OnEnable(){
        clearSelected();
        updateSelectors();
    }
    void OnDisable(){
        clearSelected();
    }

    // Start is called before the first frame update
    void Start()
    {
        updateSelectors();
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

    public void updateSelectors(){
        for(int i=0;i<selectorContent.transform.childCount;i++){
            Destroy(selectorContent.transform.GetChild(i).gameObject);
        }

        foreach(KeyValuePair<PlantSO, int> kvp in inventory.seedInventory){
            GameObject item = Instantiate(plantSelectorSlotPrefab);
            item.transform.SetParent(selectorContent.transform);
            item.transform.localScale = new Vector3(1,1,1);
            UIPSSlot script = item.GetComponent<UIPSSlot>();
            script.setPlant(kvp.Key);
            script.updateImage();
        }
    }

    public void clearSelected(){
        plantSelector.SetActive(false);
        foreach (UIPRSlot slot in currentSelected){
            slot.selected.SetActive(false);
        }
        currentSelected.Clear();
    }

    public void Plant(PlantSO p){
        if(inventory.seedInventory[p]>=currentSelected.Count){
            foreach (UIPRSlot slot in currentSelected){
                slot.harvest();
                slot.plant.setPlant(p);
                slot.plant.resetPlant();
            }
            inventory.subFromInventory(p, currentSelected.Count);
        }else{
            while(inventory.seedInventory[p]<currentSelected.Count){
                currentSelected.RemoveAt(0);
            }
            foreach (UIPRSlot slot in currentSelected){
                slot.harvest();
                slot.plant.setPlant(p);
                slot.plant.resetPlant();
            }
            inventory.subFromInventory(p, currentSelected.Count);
        }
        clearSelected();
        updateSelectors();
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
