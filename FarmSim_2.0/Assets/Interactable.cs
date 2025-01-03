using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject hover;
    private bool hovering;

    [SerializeField] private float fadeSpeed = 10;

    private util_AnimationHelper.FadeType fadeType = util_AnimationHelper.FadeType.Fade;


    [SerializeField] private UnityEvent OnClick;

    void Awake(){
        if(OnClick == null) OnClick = new UnityEvent();
    }

    void Update(){
        if(hovering && Input.GetMouseButtonDown(0)){
            OnClick.Invoke();
        }


        if(hover!=null) hover.SetActive(hovering); //util_AnimationHelper.FadeIn(hover, fadeType, fadeSpeed);
        hovering = false;
        
    }

    public void SetHover(bool h){ hovering = h;}
}
