using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInvManager : MonoBehaviour
{
    public Dictionary<PlantSO, int> seedInventory = new Dictionary<PlantSO, int>();
    public Dictionary<CropSO, int> yieldInventory = new Dictionary<CropSO, int>();

    [SerializeField] private GameObject seedUI;
    [SerializeField] private GameObject cropUI;
    [SerializeField] private GameObject itemUI;

    public GameObject slotPrefab;
    public GameObject seedContent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)) updateInfo();
    }

    public void closeAll(){
        seedUI.SetActive(false);
        cropUI.SetActive(false);
        itemUI.SetActive(false);
    }
    public void openSeedUI(){
        closeAll();
        seedUI.SetActive(true);
    }
    public void openCropUI(){
        closeAll();
        cropUI.SetActive(true);
    }
    public void openItemUI(){
        closeAll();
        itemUI.SetActive(true);
    }
    public void updateInfo(){
        foreach(KeyValuePair<PlantSO, int> plant in seedInventory){
            GameObject plantSlot = Instantiate(slotPrefab);
            UIInvSelectorSlot slotScript = plantSlot.GetComponent<UIInvSelectorSlot>();
            slotScript.setItem(plant.Key);
            slotScript.count = plant.Value;
            plantSlot.transform.SetParent(seedContent.transform);
            plantSlot.transform.localScale = new Vector3(1,1,1);
            slotScript.scrollScript.startScroll();
        }
    }
}
