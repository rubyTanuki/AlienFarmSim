using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject room;
    [SerializeField] private GameManager gm;

    private GameObject arrow;
    private bool hovering;

    private Color color;
    private float opacity;


    void OnEnable(){
        opacity = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        arrow = gameObject.transform.GetChild(0).gameObject;
        color = arrow.GetComponent<SpriteRenderer>().color;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(hovering && Input.GetMouseButtonDown(0)){
            gm.setActiveRoom(room);
        }



        if(hovering){
            fadeIn();
        }else{
            fadeOut();
        }
        hovering = false;
    }

    public void isHovering(){
        hovering = true;
    }

    public void fadeIn(){
        opacity = Mathf.Min(opacity+10f*Time.deltaTime, 1);
        color = new Color(color.r, color.g, color.b, opacity);
        arrow.GetComponent<SpriteRenderer>().color = color;
    }
    public void fadeOut(){
        opacity = Mathf.Max(opacity-10f*Time.deltaTime, 0);
        color = new Color(color.r, color.g, color.b, opacity);
        arrow.GetComponent<SpriteRenderer>().color = color;
    }
}
