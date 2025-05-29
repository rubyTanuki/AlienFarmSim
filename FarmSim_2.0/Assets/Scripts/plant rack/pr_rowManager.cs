using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_rowManager : MonoBehaviour
{
    public bool zoom;
    public PRManager manager;
    private pr_rowZoomed rowZoomed;
    private pr_rowUnZoomed rowUnZoomed;
    private UIInteractable interactScript;

    public PlantSO plant;

    public float water;
    public float light;
    public float nitrogen;
    public float phosphorus;
    public float oxygen;

    void Awake(){
        water = 35;
        light = 45f;
        nitrogen = 55f;
        phosphorus = 65f;
        oxygen = 45f;

        rowZoomed = GetComponent<pr_rowZoomed>();
        rowUnZoomed = GetComponent<pr_rowUnZoomed>();
        manager = this.transform.parent.parent.gameObject.GetComponent<PRManager>();
        interactScript = GetComponent<UIInteractable>();
    }

    void Update(){
        zoom = manager.zoomed;
        rowZoomed.enabled = zoom;
        rowUnZoomed.enabled = !zoom;
        interactScript.enabled = !zoom;

        foreach(Transform child in this.transform){
            child.gameObject.GetComponent<UIInteractable>().enabled = false;
            //(manager.selectedRow == this.gameObject);
        }
    }

    public bool isSelectedRow(){
        return manager.selectedRow == this.gameObject;
    }


}
