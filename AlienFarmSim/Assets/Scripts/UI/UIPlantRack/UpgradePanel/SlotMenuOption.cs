using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class SlotMenuOption : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject hover;
    private bool hovering;


    [SerializeField] private PlantSO seed;
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private GameObject imgObj;

    public UIPRManager manager;
    public SlotMenuManager menuManager;
    private Image img;
    // Start is called before the first frame update

    void Awake(){
        img = imgObj.GetComponent<Image>();
    }

    void OnEnable(){
        UpdateInfo();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z!=0){
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if(hover.activeSelf && Input.GetMouseButtonDown(0)){
            UIPRRowManager rowManager = manager.selectedRow.GetComponent<UIPRRowManager>();
            for(int i=0;i<6;i++){
                if(inventory.containsItem(seed)){
                    rowManager.slots[i].plantSeed(seed);
                    inventory.subFromInventory(seed, 1);
                }
            }
        }
        UpdateInfo();
        hover.SetActive(hovering);
        hovering = false;
    }

    public void OnPointerDown(PointerEventData eventData){
        // UIPRRowManager rowManager = manager.selectedRow.GetComponent<UIPRRowManager>();
        // foreach(UIPRSlot slot in rowManager.slots){
        //     if(inventory.containsItem(seed)){
        //         slot.plantSeed(seed);
        //         inventory.subFromInventory(seed, 1);
        //     }
        // }
    }

    public void setHover(bool h){ hovering = h;}

    public void setSeed(PlantSO s){
        seed = s;
        UpdateInfo();
    }
    public void setCount(int c){
        string str = "" + c;
        while (str.Length<3) str = "0" + str;
        count.SetText(str);
    }
    public void setImage(Sprite s){
        img.sprite = s;
    }

    public void UpdateInfo(){
        if(seed!=null){
            if(!inventory.containsItem(seed)){
                Destroy(this.gameObject);
                menuManager.slots.Remove(seed);
            }else{
                if(Int32.Parse(count.text) != inventory.seedInventory[seed]){
                setCount(inventory.seedInventory[seed]);
                }
                if(img.sprite != seed.image){
                    setImage(seed.image);
                }
            }
            
        }  
        
    }
}
