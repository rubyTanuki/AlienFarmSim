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




    void Awake()
    {
        img = imageObj.GetComponent<Image>();
        //populateData();
    }


    void Update()
    {
        
    }

    public void setItem(ItemSO i){
        item = i;
        populateData();
    }
    public void populateData(){
        name.SetText(item.name);
        description.SetText(item.description);
        num.SetText(count + "");
        img.sprite = item.image;
    }
    public void setCount(int c){
        count = c;
        populateData();
    }
}
