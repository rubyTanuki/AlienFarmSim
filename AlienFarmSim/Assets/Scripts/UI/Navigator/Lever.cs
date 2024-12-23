using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public NavigatorManager navManager;
    private Vector3 mousePosition;
    public float moveSpeed = 10f;

    private bool hovering;

    private bool grabbed;

    private bool launched;


    void OnEnable(){
        hovering = false;
        grabbed = false;
        launched = false;
        transform.position = new Vector2(transform.position.x, 3.7f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetMouseButtonDown(0) && hovering && !launched)
            grabbed = true;
        if(!Input.GetMouseButton(0) || launched)
            grabbed = false;
        
        if(grabbed)
            goToMouseY();
        

        hovering = false;
    }

    public void isHovering(){ hovering = true;}

    public void goToMouseY(){
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Debug.Log(mousePosition.y);
        Vector2 targetPosition = new Vector2(transform.position.x, Mathf.Clamp(mousePosition.y, -5f, 3.7f)); 
        transform.position = Vector2.Lerp(transform.position, targetPosition, moveSpeed*Time.deltaTime);

        if(transform.position.y <-3.8){
            launch();
            grabbed = false;
        }
    }

    public void launch(){
        launched = true;
        GameManager.setCurrentPlanet(navManager.targetPlanet);
        Debug.Log("LAUNCHING TO " + navManager.targetPlanet.name);
    }

}
