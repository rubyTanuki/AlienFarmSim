using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class inventory
{

    //Call subFromInventory(ItemSO) or (ItemSO, int) for removing
    //Call addToInventory(ItemSO) or (ItemSO, int) for adding


    private static int money;

    public static Dictionary<PlantSO, int> seedInventory = new Dictionary<PlantSO, int>();
    public static Dictionary<CropSO, int> cropInventory = new Dictionary<CropSO, int>();
    public static Dictionary<ItemSO, int> itemInventory = new Dictionary<ItemSO, int>();

    public static List<PlantSO> starterSeeds = new List<PlantSO>();


    public static int  getMoney()            { return money; }
    public static void setMoney(int m)       { money = m;    }
    public static void addMoney(int m)       { money+=m;     }
    public static void subMoney(int m)  { money-=m;     }


    public static bool containsItem(PlantSO p){
        return seedInventory.ContainsKey(p);
    }
    public static bool containsItem(CropSO c){
        return cropInventory.ContainsKey(c);
    }
    public static bool containsItem(ItemSO i){
        return itemInventory.ContainsKey(i);
    }







    //removing seeds

    public static void subFromInventory(PlantSO p){
        Debug.Log("subtracting 1 " + p);
        if(seedInventory.ContainsKey(p)){
            seedInventory[p]--;
            if(seedInventory[p]<=0)
                seedInventory.Remove(p);
        }
    }
    public static void subFromInventory(PlantSO p, int i){
        Debug.Log("subtracting " + i + " " + p);
        if(seedInventory.ContainsKey(p)){
            seedInventory[p]-=i;
            if(seedInventory[p]<=0)
                seedInventory.Remove(p);
        }
        
    }

    //removing crops

    public static void subFromInventory(CropSO c){
        if(cropInventory.ContainsKey(c)){
            cropInventory[c]--;
            if(cropInventory[c]<=0)
                cropInventory.Remove(c);
        }
    }
    public static void subFromInventory(CropSO c, int i){
        if(cropInventory.ContainsKey(c)){
            cropInventory[c]-=i;
            if(cropInventory[c]<=0)
                cropInventory.Remove(c);
        }
            
    }

    //removing items

    public static void subFromInventory(ItemSO n){
        if(itemInventory.ContainsKey(n))
            itemInventory[n]--;
        if(itemInventory[n]<=0)
            itemInventory.Remove(n);
    }
    public static void subFromInventory(ItemSO n, int i){
        if(itemInventory.ContainsKey(n))
            itemInventory[n]-=i;
        if(itemInventory[n]<=0)
            itemInventory.Remove(n);
    }


    //adding plants

    public static void addToInventory(PlantSO p){
        Debug.Log("Added plant " + p);
        if(seedInventory.ContainsKey(p)){
            seedInventory[p]++;
        }else{
            seedInventory.Add(p, 1);
        }
    }
    public static void addToInventory(PlantSO p, int i){
        Debug.Log("Added plant " + p);
        if(seedInventory.ContainsKey(p)){
            seedInventory[p]+=i;
        }else{
            seedInventory.Add(p, i);
        }
    }

    //adding crops

    public static void addToInventory(CropSO c){
        Debug.Log("Added crop " + c);
        if(cropInventory.ContainsKey(c)){
            cropInventory[c]++;
        }else{
            cropInventory.Add(c, 1);
        }
    }
    public static void addToInventory(CropSO c, int i){
        Debug.Log("Added crop " + c);
        if(cropInventory.ContainsKey(c)){
            cropInventory[c]+=i;
        }else{
            cropInventory.Add(c, i);
        }
    }

    //adding items

    public static void addToInventory(ItemSO n){
        Debug.Log("Added item " + n);
        if(itemInventory.ContainsKey(n)){
            itemInventory[n]++;
        }else{
            itemInventory.Add(n, 1);
        }
    }
    public static void addToInventory(ItemSO n, int i){
        Debug.Log("Added item " + n);
        if(itemInventory.ContainsKey(n)){
            itemInventory[n]+=i;
        }else{
            itemInventory.Add(n, i);
        }
    }

}
