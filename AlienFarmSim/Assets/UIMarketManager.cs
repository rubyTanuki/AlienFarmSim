using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMarketManager : MonoBehaviour
{
    [SerializeField] private GameObject selectorPrefab;
    [SerializeField] private GameObject seedSelectorContent;
    [SerializeField] private GameObject invManager;
    private UIInvManager invManagerScript;

    void Awake()
    {
        invManagerScript = invManager.GetComponent<UIInvManager>();
    }

    void OnEnable(){
        populateSelectors();
    }

    public void populateSelectors(){
        for(int i=0;i<seedSelectorContent.transform.childCount;i++){
            Destroy(seedSelectorContent.transform.GetChild(i).gameObject);
        }

        //add all the plant objects
        foreach(KeyValuePair<PlantSO, int> kvp in invManagerScript.seedInventory){
            GameObject selector = Instantiate(selectorPrefab);
            selector.transform.SetParent(seedSelectorContent.transform);
            selector.transform.localScale = new Vector3(1,1,1);
            UIMarketSelectorSlot script = selector.GetComponent<UIMarketSelectorSlot>();
            script.setItem(kvp.Key);
            script.setNumInInv(kvp.Value);
            script.setPrice(kvp.Key.baseValue);
            script.updateInfo();
        }
    }
}
