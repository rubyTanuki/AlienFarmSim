using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSwitch : MonoBehaviour
{
    public GameObject launchSwitchUI;
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
        launchSwitchUI.SetActive(true);
        GameManager.addToCloses(()=> launchSwitchUI.SetActive(false));
    }
}
