using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UIInteractable : MonoBehaviour
{
    [SerializeField] public UnityEvent OnLeftClick;
    [SerializeField] public UnityEvent OnRightClick;
    [SerializeField] public UnityEvent OnHover;

    [SerializeField] private GameObject hover;
    private bool hovering;
    private bool lastHovering;

    void Awake(){
        if(OnLeftClick == null) OnLeftClick = new UnityEvent();
        if(OnRightClick == null) OnRightClick = new UnityEvent();
        if(OnHover == null) OnHover = new UnityEvent();
    }

    void Update(){
        if(hovering && Input.GetMouseButtonDown(0)){
            // Debug.Log("Left Clicked");
            OnLeftClick.Invoke();
        }else if(hovering && Input.GetMouseButtonDown(1)){
            // Debug.Log("Right Clicked");
            OnRightClick.Invoke();
        }

        if(hovering && !lastHovering) OnHover.Invoke();


        if(hover != null) hover.SetActive(hovering);
        lastHovering = hovering;
        hovering = false;
    }

    void OnDisable(){
        if(hover!=null) hover.SetActive(false);
    }
    
    public void SetHover(bool h){ hovering = h;}

    

}
