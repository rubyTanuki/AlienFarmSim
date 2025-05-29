using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pr_PlantSelectorSlot : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Image seedImage;
    public FlipNumberScript flipNum;

    public PlantSO plant;

    public int num;

    private UIInteractable interactable;
    public pr_InfoPanelManager infoManager;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<UIInteractable>();
        interactable.OnLeftClick.AddListener(setSelectedPlant);
        interactable.OnRightClick.AddListener(clearSelectedPlant);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inventorySingleton.inv.seedInventory.ContainsKey(plant.seed))
        {
            Destroy(this.gameObject);
            return;
        }
        flipNum.SetNum(inventorySingleton.inv.seedInventory[plant.seed]);
        nameText.text = plant.extendedName;
        seedImage.sprite = plant.seed.seedPackage;
        seedImage.SetNativeSize();
    }

    void setSelectedPlant(){
        infoManager.setPlant(plant);
    }

    void clearSelectedPlant(){
        infoManager.setPlant(null);
    }

    public void setPlant(PlantSO plant, int n){
        this.plant = plant;
        num = n;
    }

    
}
