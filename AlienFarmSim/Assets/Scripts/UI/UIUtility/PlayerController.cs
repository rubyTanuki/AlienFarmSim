using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 mouseWorld;
    private static Stack<Action> closes = new Stack<Action>();
    public GameObject currentUIOpen;
    public GameObject overlay;
    int UILayer;

    private bool hoveringOverInteractable;
    private bool lastHoveringOverInteractable;
    private bool interactPromptActive;
    [SerializeField] private GameObject interactPrompt;

    float closeBufferTime;

    // Start is called before the first frame update
    void Start()
    {
        UILayer = LayerMask.NameToLayer("UI");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(IsPointerOverUIElement() ? "Over UI" : "Not over UI");
        //if(UIOpen.Count>0) currentUIOpen = UIOpen.Peek();
        //else currentUIOpen = null;

        List<RaycastResult> results = GetEventSystemRaycastResults();

        for(int i=0;i<results.Count;i++){
            RaycastResult curRaycastResult = results[i];

            switch(curRaycastResult.gameObject.tag){
                case "InvSelectorSlot":
                    curRaycastResult.gameObject.GetComponent<UIInvSelectorSlot>().setHover(true);
                    break;
                case "PlantSlot":
                    curRaycastResult.gameObject.GetComponent<UIPRSlot>().setHover(true);
                    break;
                case "PlantSelectorSlot":
                    curRaycastResult.gameObject.GetComponent<UIPSSlot>().setSelected(true);
                    break;
                case "MarketSelectorSlot":
                    curRaycastResult.gameObject.GetComponent<UIMarketSelectorSlot>().setHover(true);
                    break;
                case "EnvironmentSelectorSlot":
                    curRaycastResult.gameObject.GetComponent<EnvironmentSelector>().setHover(true);
                    break;
                case "PlantRackRow":
                    UIPRRowManager rowManager = curRaycastResult.gameObject.GetComponent<UIPRRowManager>();
                    if(rowManager.interactable()) activateInteractPrompt();
                    rowManager.setHover(true);
                    break;
                case "PRUpgraderSelector":
                    curRaycastResult.gameObject.GetComponent<UIPRUpgraderSelector>().setHover(true);
                    break;
                case "RowUpgradeMenuOption":
                    curRaycastResult.gameObject.GetComponent<RowUpgradeMenuOption>().setHover(true);
                    break;
                case "SlotMenuOption":
                    curRaycastResult.gameObject.GetComponent<SlotMenuOption>().setHover(true);
                    break;
            }
        }
        if(Input.GetKeyDown("escape")){
            if(closes.Count!=0){
                exitCurrentUIOpen();
            }else{
                openSettings();
            }
        }
        if(!hoveringOverInteractable && lastHoveringOverInteractable){
            interactPrompt.GetComponent<FollowMouse>().fadeOut();
        }

        if(closes.Count==0) overlay.SetActive(true);
        else overlay.SetActive(false);

        
        lastHoveringOverInteractable = hoveringOverInteractable;
        hoveringOverInteractable = false;
    }

    public void activateInteractPrompt(){
        hoveringOverInteractable = true;
        interactPromptActive = true;
        interactPrompt.SetActive(true);
        interactPrompt.GetComponent<FollowMouse>().fadeIn();
    }

    public void openSettings(){

    }

    public bool IsPointerOverUIElement(){
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }
    public bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults){
        for(int index = 0; index < eventSystemRaycastResults.Count; index++){
            RaycastResult curRaycastResult = eventSystemRaycastResults[index];
            if(curRaycastResult.gameObject.layer == UILayer)
            return true;
        }
        return false;
    }

    static List<RaycastResult> GetEventSystemRaycastResults(){
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }

    public static void addToCloses(Action a){
        closes.Push(a);
    }


    public void exitCurrentUIOpen(){
        Action a = closes.Pop();
        a();
    }
}
