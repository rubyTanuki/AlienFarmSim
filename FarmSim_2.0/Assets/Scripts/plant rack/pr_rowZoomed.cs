using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_rowZoomed : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;

    [SerializeField] private pr_rowManager rowManager;
    // Start is called before the first frame update
    void Start()
    {
        rowManager = GetComponent<pr_rowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HarvestAll(){
        foreach(Transform child in transform){
            PRPlantManager plantManager = child.gameObject.GetComponent<PRPlantManager>();
            plantManager.HarvestPlant();
        }
    }

    public void PlantAll(SeedSO seed){
        PlantAll(seed.plant);
    }
    public void PlantAll(PlantSO plant)
    {
        if (inventorySingleton.inv.seedInventory[plant.seed] < plant.rowAmt)
        {
            Debug.Log("Not Enough Seeds");
            return;
        }

        rowManager.plant = plant;
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < plant.rowAmt; i++)
        {
            GameObject slot = (Instantiate(slotPrefab) as GameObject);
            slot.transform.localScale = new Vector3(0, 0, 0);
            slot.transform.SetParent(this.transform);
            slot.transform.localScale = new Vector3(1, 1, 1);
            slot.GetComponent<PRSlotManager>().setManager(GetComponent<pr_rowManager>());
            slot.GetComponent<PRSlotManager>().plantManager.SetPlant(plant);

        }
        inventorySingleton.inv.SubtractItemFromInventory(plant.seed, plant.rowAmt);
    }
}
