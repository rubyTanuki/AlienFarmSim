using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class util_invUpdateManager : MonoBehaviour
{
    public static util_invUpdateManager singleton;

    public GameObject updatePrefab;

    public Dictionary<ItemSO, GameObject> updateList = new Dictionary<ItemSO, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if(singleton != null && singleton != this){
            Destroy(this);
        }else{
            singleton = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddUpdate(ItemSO item, int num){
        if(updateList.ContainsKey(item) && updateList[item].GetComponent<util_invUpdate>().GetAge()<.8f){
            util_invUpdate hUpdate = updateList[item].GetComponent<util_invUpdate>();
            hUpdate.count += num;
            //hUpdate.resetTimer();
        }else{
            GameObject update = Instantiate(updatePrefab);
            util_invUpdate script = update.GetComponent<util_invUpdate>();
            script.updateManager = this;
            script.item = item;
            script.count = num;
            script.updateManager = this;
            update.transform.SetParent(this.gameObject.transform, false);
            if(updateList.ContainsKey(item)){
                updateList[item] = update;
            }else{
                updateList.Add(item, update);
            }
            
        }


        // if(!updateList.ContainsKey(item)){
        //     //make new update object
            
        // }
        // else{
        //     //edit existing update object
            
        // }
    }
}
