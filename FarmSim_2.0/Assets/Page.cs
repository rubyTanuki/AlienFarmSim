using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{

    [SerializeField] private bool closeOnInit = true;


    public void Awake(){
        if(Time.time<.1f) this.gameObject.SetActive(!closeOnInit);
    }

    public void Close(){
        this.gameObject.SetActive(false);
    }

    public void Open(){
        this.gameObject.SetActive(true);
        PageManager.AddOpenPage(this);
    }
}
