using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private IDataService DataService = new JsonDataService();

    private InventorySerializer invSerializer = new InventorySerializer();


    public void OnEnable(){
        GameManager.addToCloses(()=>this.gameObject.SetActive(false));
    }
    public void SerializeJson(){
        invSerializer.Pull();
        if(DataService.SaveData("/inventory.json", invSerializer, false)){

        }

        // try{
        //     InventorySerializer returnedInvSerializer = DataService.LoadData<InventorySerializer>("/inventory.json", false);
        //     returnedInvSerializer.Push();
        // }catch(Exception e){
        //     Debug.LogError($"unable to load data due to: {e.Message} {e.StackTrace}");
        // }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
