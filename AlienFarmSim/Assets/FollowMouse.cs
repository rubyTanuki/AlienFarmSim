using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowMouse : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    private float opacity;
    private SpriteRenderer renderer;
    private Color color;
    private Color textColor;

    private bool fadingOut;

    [SerializeField] private TextMeshPro text;

    void Awake(){
        renderer = GetComponent<SpriteRenderer>();
        color = renderer.material.color;
        text.overrideColorTags = true;
        textColor = text.color;
    }
    void OnEnable(){
        fadingOut = false;
        opacity = 0;
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 targetPosition = new Vector2(mousePosition.x+.7f, mousePosition.y+.3f);
        transform.position = targetPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        color.a = opacity;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadingOut){
            if(opacity>0) opacity -= 6f*Time.deltaTime;
            if(opacity<0) opacity = 0;
            if(opacity == 0) gameObject.SetActive(false);
        }else{
            if(opacity<1) opacity +=6f*Time.deltaTime;
            if(opacity>1) opacity = 1;
        }

        color = new Color(color.r, color.g, color.b, opacity);
        textColor = new Color(textColor.r, textColor.g, textColor.b, opacity);
        renderer.material.color = color;
        text.color = textColor;
        

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 targetPosition = new Vector2(mousePosition.x+.7f, mousePosition.y+.3f);
        transform.position = Vector2.Lerp(transform.position, targetPosition, moveSpeed*Time.deltaTime);
    }

    public void fadeOut(){
        fadingOut = true;
    }
    public void fadeIn(){
        fadingOut = false;
    }
    
}
