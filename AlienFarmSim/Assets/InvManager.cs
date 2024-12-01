using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    public GameObject inventory;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(inventory.activeSelf) Close();
            else Open();
        }
    }

    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && !pc.IsPointerOverUIElement()){
            Open();
        }
    }

    public void Open(){
        inventory.SetActive(true);
        pc.setCurrentUIOpen(inventory);
    }
    public void Close(){
        if(pc.currentUIOpen == inventory)
            pc.closeCurrentUIOpen();
    }
}
