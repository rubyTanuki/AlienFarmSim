using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Page : MonoBehaviour
{

    [SerializeField] private bool closeOnInit = true;

    [SerializeField] private UnityEvent OnClose;


    public void Awake(){
        if(OnClose == null) OnClose = new UnityEvent();
        if(Time.time<.1f) this.gameObject.SetActive(!closeOnInit);
    }

    void Start(){

    }

    public void Close(){
        OnClose.Invoke();
        this.gameObject.SetActive(false);
    }

    public void Open(){
        this.gameObject.SetActive(true);
        PageManager.AddOpenPage(this);
    }

    public void OpenRoot(){
        this.gameObject.SetActive(true);
    }
}
