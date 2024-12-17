using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HarvestUpdateManager : MonoBehaviour
{
    public GameObject updatePrefab;

    public Dictionary<ItemSO, GameObject> updateList = new Dictionary<ItemSO, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        inventory.updateManager = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addUpdate(ItemSO item, int num){
        if(!updateList.ContainsKey(item)){
            //make new update object
            GameObject update = Instantiate(updatePrefab);
            HarvestUpdate script = update.GetComponent<HarvestUpdate>();
            script.item = item;
            script.count = num;
            script.updateManager = this;
            update.transform.SetParent(this.gameObject.transform, false);
            updateList.Add(item, update);
        }
        else{
            //edit existing update object
            HarvestUpdate hUpdate = updateList[item].GetComponent<HarvestUpdate>();
            hUpdate.count += num;
            hUpdate.resetTimer();
        }
    }
}
