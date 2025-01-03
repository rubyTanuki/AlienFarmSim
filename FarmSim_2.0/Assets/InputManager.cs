using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape)){
            PageManager.ClosePage();
        }

        List<RaycastResult> eventSystem_Results = GetEventSystemRaycastResults();
        
        for(int i=0;i<eventSystem_Results.Count;i++){
            RaycastResult curRaycastResult = eventSystem_Results[i];
            switch(curRaycastResult.gameObject.tag){
                case "Interactable":
                    curRaycastResult.gameObject.GetComponent<Interactable>().SetHover(true);
                    break;
            }
        }
        
        RaycastHit2D[] physics2D_results = GetPhysics2DRaycastResults();
        foreach(RaycastHit2D hit in physics2D_results){
            switch(hit.transform.gameObject.tag){
                case "Interactable":
                    hit.transform.gameObject.GetComponent<Interactable>().SetHover(true);
                break;
            }
        }
    }

    static List<RaycastResult> GetEventSystemRaycastResults(){
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }

    static RaycastHit2D[] GetPhysics2DRaycastResults(){
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector2(0,0), 1f);
        return hits;
    }
}
