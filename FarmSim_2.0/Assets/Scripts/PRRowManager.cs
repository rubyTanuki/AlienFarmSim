using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRRowManager : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;  

    private PRManager manager;
    private UIInteractable interactScript;

    private Page page;

    private bool zoomed;

    public GameObject selectedSlot;

    // Start is called before the first frame update
    void Awake()
    {
        page = GetComponent<Page>();
        manager = this.transform.parent.parent.gameObject.GetComponent<PRManager>();
        interactScript = GetComponent<UIInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        zoomed = manager.zoomed;
        interactScript.enabled = !zoomed;

        if(manager.selectedRow != this.gameObject) selectedSlot=null;
        foreach(Transform child in this.transform){
            child.gameObject.GetComponent<UIInteractable>().enabled = (manager.selectedRow == this.gameObject);
        }
    }

    // public void ZoomIn(){
    //     zoomed = true;
    //     rectTransform.localScale = new Vector3(1.3f,1.3f,1);
    // }
    // public void ZoomOut(){
    //     zoomed = false;
    //     rectTransform.localScale = new Vector3(1,1,1);
    // }

    public void SetSelected(GameObject obj){
        selectedSlot = obj;
    }
}
