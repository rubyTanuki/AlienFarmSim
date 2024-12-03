using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRManager : MonoBehaviour
{
    public GameObject rack;
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
        rack.SetActive(true);
        pc.setCurrentUIOpen(rack);
    }
}
