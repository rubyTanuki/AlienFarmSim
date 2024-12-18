using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPRUpgraderSelector : MonoBehaviour
{

    [SerializeField] private GameObject hover;
    private bool hovering;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        hover.SetActive(hovering);
        hovering = false;
    }

    public void setHover(bool h){
        hovering = h;
    }


}
