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

    void Awake(){
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
