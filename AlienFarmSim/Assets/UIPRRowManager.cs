using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPRRowManager : MonoBehaviour
{
    private List<UIPRSlot> slots = new List<UIPRSlot>();

    [SerializeField] private GameObject rowUpgrader;

    [SerializeField] private RowEnvironmentSO environment;

    [SerializeField] private GameObject upgradePanel;

    [SerializeField] private UIPRManager rackManager;

    private bool isHovering;

    private bool zoom;
    private bool buffer;

    private GameObject content;
    private RectTransform contentRectTransform;

    private Vector2 baseSizeDelta = new Vector2(660,370);
    private Vector2 basePosition = new Vector2(0,0);

    private Vector2 zoomedSizeDelta;
    private Vector2 zoomedPosition;
    
    //environment options
    public static List<RowEnvironmentSO> environmentOptions = new List<RowEnvironmentSO>();
    //vessel options (get them from the active environment)
    //fertilizer options (get them from the active environment)


    void Start(){
        StartCoroutine("WaitToInitZoomedPosition");
        zoomedSizeDelta = new Vector2(1056, 592);
        

        content = this.gameObject.transform.parent.gameObject;
        contentRectTransform = content.GetComponent<RectTransform>();

        foreach(Transform child in transform){
            slots.Add(child.gameObject.GetComponent<UIPRSlot>());
        }
    }

    void OnEnable(){
        StartCoroutine("EnableBuffer");
    }
    void OnDisable(){
        buffer = false;
    }
    
    void Update(){
        if(isHovering && Input.GetKeyDown(KeyCode.F) && buffer && !rackManager.zoomed){
            zoom = true;
            rackManager.zoomed = true;
            PlayerController.addToCloses(unZoom);
        }

        if(zoom) zoomIn();
        else zoomOut();
        
        isHovering = false;
    }




    private IEnumerator EnableBuffer(){
        for(int i=0;i<3;i++) yield return null;
        buffer = true;
    }

    private IEnumerator WaitToInitZoomedPosition(){
        for(int i=0;i<3;i++)
            yield return null;
        RectTransform rectTransform = this.gameObject.GetComponent<RectTransform>();
        zoomedPosition = new Vector2(0, -400 -(185+rectTransform.anchoredPosition.y)*3.2f);
    }

    public bool interactable(){
        return !rackManager.zoomed;
    }
    
    public void unZoom(){
        zoom = false;
        rackManager.zoomed = false;
    }

    public void setHover(bool h){
        isHovering = h;
    }

    public void harvestAll(){
        foreach(UIPRSlot slot in slots){
            slot.harvest();
        }
    }

    public void toggleRowUpgrader(){
        rowUpgrader.SetActive(!rowUpgrader.activeSelf);
    }

    public void setEnvironment(RowEnvironmentSO env){
        environment = env;
    }

    public RowEnvironmentSO getEnvironment(){
        return environment;
    }

    public void zoomIn(){
        RectTransform upgradeRectTransform = upgradePanel.GetComponent<RectTransform>();

        upgradeRectTransform.anchoredPosition = Vector2.Lerp(
            upgradeRectTransform.anchoredPosition,
            new Vector2(0, -600), 
            Time.deltaTime*3
        );
        contentRectTransform.sizeDelta = Vector2.Lerp(
            contentRectTransform.sizeDelta,
            zoomedSizeDelta, Time.deltaTime*1.75f);
        contentRectTransform.anchoredPosition = Vector2.Lerp(
            contentRectTransform.anchoredPosition, 
            zoomedPosition, Time.deltaTime*3);
    }
    public void zoomOut(){
        RectTransform upgradeRectTransform = upgradePanel.GetComponent<RectTransform>();
        upgradeRectTransform.anchoredPosition = Vector2.Lerp(
            upgradeRectTransform.anchoredPosition,
            new Vector2(0, 500), 
            Time.deltaTime*3
        );
        contentRectTransform.sizeDelta = Vector2.Lerp(
            contentRectTransform.sizeDelta,
            baseSizeDelta, Time.deltaTime*1.75f);
        contentRectTransform.anchoredPosition = Vector2.Lerp(
            contentRectTransform.anchoredPosition, 
            basePosition, Time.deltaTime*3);
    }
}

