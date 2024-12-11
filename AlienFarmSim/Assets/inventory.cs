using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{

    //Call subFromInventory(ItemSO) or (ItemSO, int) for removing
    //Call addToInventory(ItemSO) or (ItemSO, int) for adding


    private int money;

    public Dictionary<PlantSO, int> seedInventory = new Dictionary<PlantSO, int>();
    public Dictionary<CropSO, int> cropInventory = new Dictionary<CropSO, int>();
    public Dictionary<ItemSO, int> itemInventory = new Dictionary<ItemSO, int>();

    public List<PlantSO> starterSeeds = new List<PlantSO>();




    void Start(){
        money = 999;
        foreach(PlantSO plant in starterSeeds){
            seedInventory.Add(plant, 6);
        }
    }

    public int  getMoney()            { return money; }
    public void setMoney(int m)       { money = m;    }
    public void addMoney(int m)       { money+=m;     }
    public void subMoney(int m)  { money-=m;     }



    //removing seeds

    public void subFromInventory(PlantSO p){
        if(seedInventory.ContainsKey(p))
            seedInventory[p]--;
        if(seedInventory[p]<=0)
            seedInventory.Remove(p);
    }
    public void subFromInventory(PlantSO p, int i){
        if(seedInventory.ContainsKey(p))
            seedInventory[p]-=i;
        if(seedInventory[p]<=0)
            seedInventory.Remove(p);
    }

    //removing crops

    public void subFromInventory(CropSO c){
        if(cropInventory.ContainsKey(c))
            cropInventory[c]--;
        if(cropInventory[c]<=0)
            cropInventory.Remove(c);
    }
    public void subFromInventory(CropSO c, int i){
        if(cropInventory.ContainsKey(c))
            cropInventory[c]-=i;
        if(cropInventory[c]<=0)
            cropInventory.Remove(c);
    }

    //removing items

    public void subFromInventory(ItemSO n){
        if(itemInventory.ContainsKey(n))
            itemInventory[n]--;
        if(itemInventory[n]<=0)
            itemInventory.Remove(n);
    }
    public void subFromInventory(ItemSO n, int i){
        if(itemInventory.ContainsKey(n))
            itemInventory[n]-=i;
        if(itemInventory[n]<=0)
            itemInventory.Remove(n);
    }


    //adding plants

    public void addToInventory(PlantSO p){
        if(seedInventory.ContainsKey(p)){
            seedInventory[p]++;
        }else{
            seedInventory.Add(p, 1);
        }
    }
    public void addToInventory(PlantSO p, int i){
        if(seedInventory.ContainsKey(p)){
            seedInventory[p]+=i;
        }else{
            seedInventory.Add(p, i);
        }
    }

    //adding crops

    public void addToInventory(CropSO c){
        if(cropInventory.ContainsKey(c)){
            cropInventory[c]++;
        }else{
            cropInventory.Add(c, 1);
        }
    }
    public void addToInventory(CropSO c, int i){
        if(cropInventory.ContainsKey(c)){
            cropInventory[c]+=i;
        }else{
            cropInventory.Add(c, i);
        }
    }

    //adding items

    public void addToInventory(ItemSO n){
        if(itemInventory.ContainsKey(n)){
            itemInventory[n]++;
        }else{
            itemInventory.Add(n, 1);
        }
    }
    public void addToInventory(ItemSO n, int i){
        if(itemInventory.ContainsKey(n)){
            itemInventory[n]+=i;
        }else{
            itemInventory.Add(n, i);
        }
    }

}
