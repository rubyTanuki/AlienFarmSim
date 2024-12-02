using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 mouseWorld;
    private Stack<GameObject> UIOpen = new Stack<GameObject>();
    public GameObject currentUIOpen;
    int UILayer;

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
        if(UIOpen.Count>0) currentUIOpen = UIOpen.Peek();

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
            }
        }

        if(Input.GetKeyDown("escape") && UIOpen.Count>0)
        {
            closeCurrentUIOpen();
        }
    }

    public void closeCurrentUIOpen(){
        UIOpen.Pop().SetActive(false);
    }

    public void setCurrentUIOpen(GameObject obj){
        UIOpen.Push(obj);
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
}
