using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{

    public GameObject inventoryUI;
    public PlayerController pc;

    private GameObject selector;
    private bool hovering;

    // Start is called before the first frame update
    void Start()
    {
        selector = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(pc.currentUIOpen == null){
                Open();
            }
        }
        selector.SetActive(hovering);
        hovering = false;
    }

    void OnMouseOver(){
        hovering = true;
        if(Input.GetMouseButtonDown(0) && !pc.IsPointerOverUIElement()){
            Open();
        }
    }

    public void Open(){
        inventoryUI.SetActive(true);
        pc.setCurrentUIOpen(inventoryUI);
    }
    public void Close(){
        if(pc.currentUIOpen == inventoryUI)
            pc.closeCurrentUIOpen();
    }
}
