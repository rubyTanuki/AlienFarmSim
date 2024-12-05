using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInvSelectorSlot : MonoBehaviour
{
    public ItemSO item;
    public int count;

    [SerializeField] private GameObject imageObj;
    private Image img;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] public TextMeshProUGUI num;
    [SerializeField] private TextMeshProUGUI description;

    public ScrollingTextManager scrollScript;

    public GameObject hover;


    public bool isHovering = false;

    private GameObject category;

    void Awake()
    {
        img = imageObj.GetComponent<Image>();
        //populateData();
    }

    void Start(){
        category = this.gameObject.transform.parent.parent.parent.parent.gameObject;
    }


    void Update()
    {
        if(hover.activeSelf){
            if(Input.GetMouseButtonDown(0)){
                category.GetComponent<UIInvCategoryManager>().selectedItem = item;
                //GameObject.Find("UICanvas/InventoryUI/").GetComponent<UIInvManager>().selectedItem = item;
            }
        }


        hover.SetActive(isHovering);
        isHovering = false;
    }

    public void setHover(bool b){ isHovering = b; }

    public void setItem(ItemSO i){
        item = i;
    }
    public void populateData(){
        name.SetText(item.name);
        description.SetText(item.description);
        string zeros = "";
        if(count<10) zeros = "00";
        else if(count<100) zeros = "0";
        num.SetText(zeros + count);
        img.sprite = item.image;
    }
    public void setCount(int c){
        count = c;
    }
}
