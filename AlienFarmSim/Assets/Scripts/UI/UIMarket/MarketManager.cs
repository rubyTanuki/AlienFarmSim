using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    public GameObject market;
    public PlayerController pc;

    private GameObject selector;
    private bool hovering;
    

    void Start(){
        selector = this.gameObject.transform.GetChild(0).gameObject;
    }
    void Update(){


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
        market.SetActive(true);
        GameManager.addToCloses(()=>market.SetActive(false));
        //pc.setCurrentUIOpen(market);
    }
    public void Close(){
        // if(pc.currentUIOpen == market)
        //     pc.closeCurrentUIOpen();
    }
}
