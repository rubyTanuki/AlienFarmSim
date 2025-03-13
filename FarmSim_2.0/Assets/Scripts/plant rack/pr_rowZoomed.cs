using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_rowZoomed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void PlantAll(PlantSO plant){
        foreach(Transform child in transform){
            PRPlantManager plantManager = child.gameObject.GetComponent<PRSlotManager>().plantManager;
            plantManager.SetPlant(plant);
        }
    }
}
