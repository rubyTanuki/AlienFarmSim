using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_SeedSelectorManager : MonoBehaviour
{

    [SerializeField] private pr_InfoPanelManager infoPanel;

    [SerializeField] private GameObject slotPrefab;

    [SerializeField] private GameObject content;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable(){
        //destorying all already existing slots
        for (int i = content.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
        //replacing with updated slots from inventory singleton
        foreach(KeyValuePair<SeedSO, int> kvp in inventorySingleton.inv.seedInventory){
            GameObject slot = Instantiate(slotPrefab, content.transform);
            pr_PlantSelectorSlot slotScript = slot.GetComponent<pr_PlantSelectorSlot>();
            slotScript.setPlant(kvp.Key.plant, kvp.Value);
            slotScript.infoManager = infoPanel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
