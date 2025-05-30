using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class inventorySingleton : MonoBehaviour
{
    public static inventorySingleton inv;

    
    public Dictionary<ItemSO, int> itemInventory = new Dictionary<ItemSO, int>();
    public Dictionary<CropSO, int> cropInventory = new Dictionary<CropSO, int>();
    public Dictionary<SeedSO, int> seedInventory = new Dictionary<SeedSO, int>();


    [SerializeField] private List<SeedSO> starterSeeds = new List<SeedSO>();
    [SerializeField] private List<int> starterSeedsCount = new List<int>();

    public int money = 0;


    void Awake(){
        inv = this;
        if(inv != null && inv != this){
            Destroy(this);
        }else{
            inv = this;
        }

        for(int i=0;i<starterSeeds.Count;i++){
            inv.seedInventory.Add(starterSeeds[i], starterSeedsCount[i]);
        }
    }

    public int Get(ItemSO item)
    {
        if (!Contains(item)) return -1;
        switch (item)
        {
            case SeedSO s:
                return seedInventory[s];
            case CropSO c:
                return cropInventory[c];
            case ItemSO i:
                return itemInventory[i];
        }
        return -2;
    }


    /// ADDING



    //Adding item to item inventory
    public void AddItemToInventory(ItemSO item){
        AddItemToInventory(item, 1);
    }
    public void AddItemToInventory(ItemSO item, int num){
        util_invUpdateManager.singleton.AddUpdate(item, num);
        if(itemInventory.ContainsKey(item)){
            itemInventory[item] = itemInventory[item]+num;
        }else{
            itemInventory.Add(item, num);
        }
    }

    //Adding seed to seed inventory
    public void AddItemToInventory(SeedSO seed){
        AddItemToInventory(seed, 1);
    }
    public void AddItemToInventory(SeedSO seed, int num){
        util_invUpdateManager.singleton.AddUpdate(seed, num);
        if(seedInventory.ContainsKey(seed)){
            seedInventory[seed] = seedInventory[seed]+num;
        }else{
            seedInventory.Add(seed, num);
        }
    }

    //Adding crop to crop inventory
    public void AddItemToInventory(CropSO crop){
        AddItemToInventory(crop, 1);
    }
    public void AddItemToInventory(CropSO crop, int num){
        util_invUpdateManager.singleton.AddUpdate(crop, num);
        if(cropInventory.ContainsKey(crop)){
            cropInventory[crop] = cropInventory[crop]+num;
        }else{
            cropInventory.Add(crop, num);
        }
    }




    /// SUBTRACTING



    //subtracting item from item inventory
    //returns true if item is in inventory and removes properly
    public bool SubtractItemFromInventory(ItemSO item){
        return SubtractItemFromInventory(item, 1); 
    }
    public bool SubtractItemFromInventory(ItemSO item, int num){
        if(itemInventory.ContainsKey(item)) return false;
        else if(itemInventory[item]-num<0) return false;
        else{
            itemInventory[item] -= num;
            if(itemInventory[item]<=0){
                itemInventory.Remove(item);
            }
            return true;
        }
    }

    //subtracting seed from seed inventory
    //returns true if seed is in inventory and removes properly
    public bool SubtractItemFromInventory(SeedSO seed){
        return SubtractItemFromInventory(seed, 1);
    }
    public bool SubtractItemFromInventory(SeedSO seed, int num){
        if(!seedInventory.ContainsKey(seed)) return false;
        else{
            seedInventory[seed] -= num;
            if(seedInventory[seed]<=0){
                seedInventory.Remove(seed);
            }
            return true;
        }
    }

    //subtracting crop from crop inventory
    //returns true if crop is in inventory and removes properly
    public bool SubtractItemFromInventory(CropSO crop){
        return SubtractItemFromInventory(crop, 1);
    }
    public bool SubtractItemFromInventory(CropSO crop, int num){
        if(cropInventory.ContainsKey(crop)) return false;
        else if(cropInventory[crop]-num<0) return false;
        else{
            cropInventory[crop] -= num;
            if(cropInventory[crop]<=0){
                cropInventory.Remove(crop);
            }
            return true;
        }
    }




    /// CONTAINS
    
    

    public bool Contains(ItemSO item){
        switch (item)
        {
            case SeedSO s:
                return seedInventory.ContainsKey(s);
            case CropSO c:
                return cropInventory.ContainsKey(c);
            case ItemSO i:
                return itemInventory.ContainsKey(i);
        }
        return false;
    }
    


}
