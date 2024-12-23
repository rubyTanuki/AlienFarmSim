using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    public GameObject targetSelectorUI;
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
        if(pc.canOpenUI()){
            hovering = true;
            if(Input.GetMouseButtonDown(0)){
                Open();
            }
        }
    }

    public void Open(){
        targetSelectorUI.SetActive(true);
        GameManager.addToCloses(()=> targetSelectorUI.SetActive(false));
    }
}
