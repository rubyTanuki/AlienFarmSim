using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_PlantSelectorSlot : MonoBehaviour
{

    public PlantSO plant;

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
        
    }

    void setSelectedPlant(){
        infoManager.setPlant(plant);
    }

    void clearSelectedPlant(){
        infoManager.setPlant(null);
    }

    
}
