using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private UIPRManager manager;



    public Dictionary<PlantSO, GameObject> slots = new Dictionary<PlantSO, GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        updateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        updateSlots();
    }

    public void updateSlots(){
        foreach(KeyValuePair<PlantSO, int> kvp in inventory.seedInventory){
            if(slots.ContainsKey(kvp.Key)){
                slots[kvp.Key].GetComponent<SlotMenuOption>().UpdateInfo();
            }
            else{
                instantiateSlot(kvp);
            }
        }
    }

    public void instantiateSlots(){
        foreach(KeyValuePair<PlantSO, int> kvp in inventory.seedInventory){
            instantiateSlot(kvp);
        }
    }

    public void instantiateSlot(KeyValuePair<PlantSO, int> kvp){
        GameObject slot = Instantiate(slotPrefab);
        slot.transform.SetParent(content.transform);
        slot.transform.localScale = new Vector3(1,1,1);
        slot.transform.position = new Vector3(slot.transform.position.x, slot.transform.position.y, 0);
        SlotMenuOption script = slot.GetComponent<SlotMenuOption>();
        script.setSeed(kvp.Key);
        script.manager = manager;
        script.menuManager = this;
        slots.Add(kvp.Key, slot);
    }
}
