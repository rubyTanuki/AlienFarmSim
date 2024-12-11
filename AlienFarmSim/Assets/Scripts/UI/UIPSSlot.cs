using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPSSlot : MonoBehaviour
{
    public PlantSO plant;
    public GameObject selected;
    public UIPRManager manager;
    private bool select;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool leftClick = Input.GetMouseButtonDown(0);
        if(selected.activeSelf && leftClick){
            manager.Plant(plant);
        }

        selected.SetActive(select);
        select = false;
    }

    public void setSelected(bool s){
        select = s;
    }

    public void updateImage(){
        image.GetComponent<Image>().sprite = plant.sprites[4];
    }
}
