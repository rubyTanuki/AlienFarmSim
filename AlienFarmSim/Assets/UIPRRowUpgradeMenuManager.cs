using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPRRowUpgradeMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject environmentMenu;
    [SerializeField] private GameObject lightingMenu;
    [SerializeField] private GameObject sprinklerMenu;
    [SerializeField] private GameObject harvesterMenu;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void closeAll(){
        environmentMenu.SetActive(false);
        lightingMenu.SetActive(false);
        sprinklerMenu.SetActive(false);
        harvesterMenu.SetActive(false);
    }

    public void openEnvMenu(){
        closeAll();
        environmentMenu.SetActive(true);
    }
    public void openLightingMenu(){
        closeAll();
        lightingMenu.SetActive(true);
    }
    public void openSprinklerMenu(){
        closeAll();
        sprinklerMenu.SetActive(true);
    }
    public void openHarvesterMenu(){
        closeAll();
        harvesterMenu.SetActive(true);
    }
}
