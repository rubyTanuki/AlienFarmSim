using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NavigatorManager : MonoBehaviour
{
    public UIPlanetManager selectedPlanet;

    private Camera mainCamera;

    private readonly float ZOOMED_SIZE = .8f;
    private readonly float BASE_SIZE = 6;
    private readonly float ZOOM_SPEED = 6;

    void Awake(){
        mainCamera = Camera.main;
        
        if(gameObject.activeSelf){
            
            StartCoroutine(waitToInit(Close, 2));
        }
    }

    void OnEnable(){
        StartCoroutine(waitToInit(()=>this.gameObject.SetActive(false), 1));
    }
    void OnDisable(){
        if(Camera.main != null){
            Camera.main.transform.position = new Vector3(0,0,-10);
            Camera.main.orthographicSize = 6;
        }
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
        if(selectedPlanet != null){
            zoomIn();
        }else{
            zoomOut();
        }
    }

    public void Close(){
        selectedPlanet = null;
    }

    public void zoomIn(){
        Vector3 camPos = mainCamera.transform.position;
        Vector3 planetPos = selectedPlanet.gameObject.transform.position;
        Vector3 targetPos = new Vector3(planetPos.x - .6f, planetPos.y, -10);
        mainCamera.transform.position = Vector3.Lerp(camPos, targetPos, 10*Time.deltaTime);
        
        float currentSize = mainCamera.orthographicSize;
        mainCamera.orthographicSize = Mathf.Lerp(currentSize, ZOOMED_SIZE, ZOOM_SPEED*Time.deltaTime);
    }
    public void zoomOut(){
        Vector3 camPos = mainCamera.transform.position;
        Vector3 targetPos = new Vector3(0,0,-10);
        mainCamera.transform.position = Vector3.Lerp(camPos, targetPos, 10*Time.deltaTime);
        
        float currentSize = mainCamera.orthographicSize;
        mainCamera.orthographicSize = Mathf.Lerp(currentSize, BASE_SIZE, ZOOM_SPEED*Time.deltaTime);
    }

    public void setSelectedPlanet(UIPlanetManager p){
        selectedPlanet = p;
        GameManager.addToCloses(Close);
    }
}
