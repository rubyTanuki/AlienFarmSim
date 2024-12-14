using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPRRowManager : MonoBehaviour
{
    private List<UIPRSlot> slots = new List<UIPRSlot>();

    [SerializeField] private GameObject rowUpgrader;

    [SerializeField] private RowEnvironmentSO environment;

    
    
    //environment options
    public static List<RowEnvironmentSO> environmentOptions = new List<RowEnvironmentSO>();
    //vessel options (get them from the active environment)
    //fertilizer options (get them from the active environment)


    void Start(){
        foreach(Transform child in transform){
            slots.Add(child.gameObject.GetComponent<UIPRSlot>());
        }
    }

    public void harvestAll(){
        foreach(UIPRSlot slot in slots){
            slot.harvest();
        }
    }

    public void toggleRowUpgrader(){
        rowUpgrader.SetActive(!rowUpgrader.activeSelf);
    }
}
