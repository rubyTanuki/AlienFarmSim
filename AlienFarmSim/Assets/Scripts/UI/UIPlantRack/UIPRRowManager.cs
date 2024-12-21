using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPRRowManager : MonoBehaviour
{
    public List<UIPRSlot> slots = new List<UIPRSlot>();

    [SerializeField] private GameObject rowUpgrader;

    [SerializeField] private RowEnvironmentSO environment;

    [SerializeField] private GameObject upgradePanel;

    [SerializeField] private UIPRManager rackManager;

    private Image backgroundImg;

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
        zoomedSizeDelta = new Vector2(792, 444);
        
        
        content = this.gameObject.transform.parent.gameObject;
        contentRectTransform = content.GetComponent<RectTransform>();

        foreach(Transform child in transform){
            slots.Add(child.gameObject.GetComponent<UIPRSlot>());
        }

        backgroundImg = GetComponent<Image>();
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
            rackManager.selectedRow = this.gameObject;
            PlayerController.addToCloses(unZoom);
        }

        if(rackManager.selectedRow == this.gameObject){
            if(zoom) zoomIn();
            else zoomOut();
        }
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
        //Debug.Log(rectTransform.anchoredPosition.y);
        zoomedPosition = new Vector2(0,  - 140 + (-185-rectTransform.anchoredPosition.y)*1.09f);
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
        updateImage();
    }

    public void updateImage(){
        backgroundImg.sprite = environment.getBackground();
    }

    public RowEnvironmentSO getEnvironment(){
        return environment;
    }

    public void zoomIn(){
        rackManager.selectedRow = this.gameObject;
        RectTransform upgradeRectTransform = upgradePanel.GetComponent<RectTransform>();

        upgradeRectTransform.transform.position = Vector3.Lerp(
            upgradeRectTransform.transform.position,
            new Vector3(0, -1.8f, 0), 
            Time.deltaTime*4
        );
        contentRectTransform.sizeDelta = Vector2.Lerp(
            contentRectTransform.sizeDelta,
            zoomedSizeDelta, Time.deltaTime*2.2f);
        contentRectTransform.anchoredPosition = Vector2.Lerp(
            contentRectTransform.anchoredPosition, 
            zoomedPosition, Time.deltaTime*3.5f);
    }
    public void zoomOut(){
        RectTransform upgradeRectTransform = upgradePanel.GetComponent<RectTransform>();
        upgradeRectTransform.transform.position = Vector3.Lerp(
            upgradeRectTransform.transform.position,
            new Vector3(0, 7f, 0), 
            Time.deltaTime*4
        );
        contentRectTransform.sizeDelta = Vector2.Lerp(
            contentRectTransform.sizeDelta,
            baseSizeDelta, Time.deltaTime*2.2f);
        contentRectTransform.anchoredPosition = Vector2.Lerp(
            contentRectTransform.anchoredPosition, 
            basePosition, Time.deltaTime*3.5f);
    }
}

