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



    void Start()
    {
        img = imageObj.GetComponent<Image>();
        populateData();
    }


    void Update()
    {
        
    }

    public void setItem(ItemSO i){
        item = i;
        populateData();
    }
    public void populateData(){
        name.text = item.name;
        num.text = count + "";
    }
    public void setCount(int c){
        count = c;
        populateData();
    }
}
