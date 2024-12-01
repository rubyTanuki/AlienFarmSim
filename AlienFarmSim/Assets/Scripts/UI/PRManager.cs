using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRManager : MonoBehaviour
{
    public GameObject rack;
    public PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && !pc.IsPointerOverUIElement()){
            Open();
        }
    }

    public void Open(){
        rack.SetActive(true);
        pc.setCurrentUIOpen(rack);
    }
}
