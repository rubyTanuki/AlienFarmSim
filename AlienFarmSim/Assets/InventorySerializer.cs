using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySerializer
{
    public List<PlantSO> seeds = new List<PlantSO>();
    public List<int> seedCounts = new List<int>();

    public List<CropSO> crops = new List<CropSO>();
    public List<int> cropCounts = new List<int>();
    
    public List<ItemSO> items = new List<ItemSO>();
    public List<int> itemCounts = new List<int>();

    public List<RowEnvironmentSO> envMods = new List<RowEnvironmentSO>();
    public List<RowLightingSO> lightMods = new List<RowLightingSO>();

    public int money;


    public void Pull(){
        seeds = new List<PlantSO>();
        seedCounts = new List<int>();
        foreach(KeyValuePair<PlantSO, int> kvp in inventory.seedInventory){
            seeds.Add(kvp.Key);
            seedCounts.Add(kvp.Value);
        }

        crops = new List<CropSO>();
        cropCounts = new List<int>();
        foreach(KeyValuePair<CropSO, int> kvp in inventory.cropInventory){
            crops.Add(kvp.Key);
            cropCounts.Add(kvp.Value);
        }

        items = new List<ItemSO>();
        itemCounts = new List<int>();
        foreach(KeyValuePair<ItemSO, int> kvp in inventory.itemInventory){
            items.Add(kvp.Key);
            itemCounts.Add(kvp.Value);
        }

        envMods = inventory.environmentModules;
        lightMods = inventory.lightingModules;
        money = inventory.getMoney();
    }

    public void Push(){
        Debug.Log("Pushing to main inventory");
        Dictionary<PlantSO, int> s = new Dictionary<PlantSO, int>();
        Dictionary<CropSO, int> c = new Dictionary<CropSO, int>();
        Dictionary<ItemSO, int> i = new Dictionary<ItemSO, int>();
        for(int j=0;j<Mathf.Max(crops.Count, seeds.Count, items.Count);j++){
            if(j<seeds.Count) s.Add(seeds[j], seedCounts[j]);
            if(j<crops.Count) c.Add(crops[j], cropCounts[j]);
            if(j<items.Count) i.Add(items[j], itemCounts[j]);
        }

        inventory.seedInventory = s;
        inventory.cropInventory = c;
        inventory.itemInventory = i;

        inventory.environmentModules = envMods;
        inventory.lightingModules = lightMods;
        inventory.setMoney(1);
    }
}
