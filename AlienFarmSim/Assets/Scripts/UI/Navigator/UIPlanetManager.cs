using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlanetManager : MonoBehaviour
{
    public NavigatorManager navManager;
    public Image planetImage;

    public PlanetSO planet;

    public GameObject hover;
    private bool hovering;

    private Sprite lowResSprite;
    public Sprite highResSprite;

    private float bufferTimer;

    private Color color;
    private float opacity;
    // Start is called before the first frame update
    void Start()
    {
        lowResSprite = planetImage.sprite;
        if(hover!=null){
            color = hover.GetComponent<Image>().color;
            opacity = color.a;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(navManager.selectedPlanet == this){
            planetImage.sprite = highResSprite;
            bufferTimer =Time.time;
            if(hover!=null)hover.SetActive(false);
        }else{
            if(Time.time-bufferTimer>.05f){
                planetImage.sprite = lowResSprite;
                if(hover!=null)hover.SetActive(true);
            }
            
        }
        if(hover!=null){
            if(Time.time-bufferTimer>.3f){
                //hover.SetActive(false);
                fade(hovering);
            }else{
                fadeOut();
                //hover.SetActive(navManager.selectedPlanet != this);
            }
            
        }
        
       
        hovering = false;
    }


    public void fade(bool b){
        if(b) fadeIn();
        else fadeOut();
    }
    public void fadeIn(){
        opacity = Mathf.Min(opacity+5f*Time.deltaTime, 1);
        color = new Color(color.r, color.g, color.b, opacity);
        hover.GetComponent<Image>().color = color;
        //Debug.Log(hover.GetComponent<Image>().color.a);
    }
    public void fadeOut(){
        
        opacity = Mathf.Max(opacity-5f*Time.deltaTime, 0);
        color = new Color(color.r, color.g, color.b, opacity);
        hover.GetComponent<Image>().color = color;
        //Debug.Log(hover.GetComponent<Image>().color.a);
    }


    public void IsOver(){
        hovering = true;
        if(Input.GetMouseButtonDown(0)){
            navManager.setSelectedPlanet(this);
        }
    }
}
