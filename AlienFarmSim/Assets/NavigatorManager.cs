using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NavigatorManager : MonoBehaviour
{
    public UIPlanetManager selectedPlanet;
    public GameObject planetSelectPanel;
    public GameObject planets;

    private Camera mainCamera;

    private readonly float ZOOMED_SIZE = .6f;
    private readonly float BASE_SIZE = 6;
    private readonly float ZOOM_SPEED = 8;

    private readonly float SCROLL_SPEED = 10;
    private float startScale;

    private Vector3 selectPanelOut = new Vector3(-350, 0, 0);
    private Vector3 selectPanelIn = new Vector3(25, 0, 0);

    void Awake(){
        mainCamera = Camera.main;
        startScale = planets.transform.localScale.x;
        
        if(gameObject.activeSelf){
            StartCoroutine(waitToInit(Close, 2));
        }
    }

    void OnEnable(){
        Vector2 scaleVector = new Vector2(startScale, startScale);
        planets.transform.localScale = scaleVector;

        StartCoroutine(waitToInit(()=>this.gameObject.SetActive(false), 1));
    }
    void OnDisable(){
        if(Camera.main != null){
            Camera.main.transform.position = new Vector3(0,0,-10);
            Camera.main.orthographicSize = 6;
        }
        if(planetSelectPanel!=null) planetSelectPanel.SetActive(false);
    }
    private IEnumerator waitToInit(Action a, int frames){
        for(int i=0;i<frames;i++){ yield return null; }
        GameManager.addToCloses(a);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MWDelta = Input.mouseScrollDelta.y;
        float num = MWDelta * SCROLL_SPEED * Time.deltaTime;
        planets.transform.localScale = new Vector2(planets.transform.localScale.x + num, planets.transform.localScale.y + num);


        if(!planetSelectPanel.activeSelf) planetSelectPanel.SetActive(true);
        if(selectedPlanet != null){
            zoomIn();
        }else{
            zoomOut();
        }

        
    }

    public void Close(){
        selectedPlanet = null;
        planetSelectPanel.SetActive(false);
    }

    public void zoomIn(){
        Vector3 camPos = mainCamera.transform.position;
        Vector3 planetPos = selectedPlanet.gameObject.transform.position;
        Vector3 targetPos = new Vector3(planetPos.x - .45f, planetPos.y, -10);
        mainCamera.transform.position = Vector3.Lerp(camPos, targetPos, 10*Time.deltaTime);
        
        float currentSize = mainCamera.orthographicSize;
        mainCamera.orthographicSize = Mathf.Lerp(currentSize, ZOOMED_SIZE, ZOOM_SPEED*Time.deltaTime);
        
        RectTransform selectPanelTransform = planetSelectPanel.GetComponent<RectTransform>();
        Vector3 anchoredPos = selectPanelTransform.anchoredPosition;
        selectPanelTransform.anchoredPosition = Vector3.Lerp(anchoredPos, selectPanelIn, 6*Time.deltaTime);
    }
    public void zoomOut(){
        Vector3 camPos = mainCamera.transform.position;
        Vector3 targetPos = new Vector3(0,0,-10);
        mainCamera.transform.position = Vector3.Lerp(camPos, targetPos, 10*Time.deltaTime);
        
        float currentSize = mainCamera.orthographicSize;
        mainCamera.orthographicSize = Mathf.Lerp(currentSize, BASE_SIZE, ZOOM_SPEED*Time.deltaTime);

        RectTransform selectPanelTransform = planetSelectPanel.GetComponent<RectTransform>();
        Vector3 anchoredPos = selectPanelTransform.anchoredPosition;
        selectPanelTransform.anchoredPosition = Vector3.Lerp(anchoredPos, selectPanelOut, 6*Time.deltaTime);
    }

    public void setSelectedPlanet(UIPlanetManager p){
        selectedPlanet = p;
        GameManager.addToCloses(Close);
    }
}
