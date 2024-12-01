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
    [SerializeField] private TextMeshProUGUI num;
    [SerializeField] private TextMeshProUGUI description;

    public GameObject hover;

    private bool isHovering = false;

    void Start()
    {
        img = imageObj.GetComponent<Image>();
        populateData();
    }


    void Update()
    {
        hover.SetActive(isHovering);
        isHovering = false;
    }
    public void setHover(bool b){ isHovering = b; }

    public void setItem(ItemSO i){
        item = i;
        populateData();
    }
    public void populateData(){
        name.text = "";
        description.text = "";
        num.text = "000";

        name.SetText(item.name);
        description.SetText(item.description);

        if(count<10) num.SetText("00" + count);
        else if(count<100) num.SetText("0" + count);
        else num.SetText("" + count);

        img.sprite = item.image;
    }
    public void setCount(int c){
        count = c;
        populateData();
    }
}
