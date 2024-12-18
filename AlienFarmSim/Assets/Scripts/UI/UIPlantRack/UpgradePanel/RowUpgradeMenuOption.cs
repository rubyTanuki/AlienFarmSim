using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RowUpgradeMenuOption : MonoBehaviour
{

    [SerializeField] private GameObject hover;
    private bool hovering;

    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject imgObj;
    private Image img;


    // Start is called before the first frame update
    void Awake()
    {
        img = imgObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z!=0){
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        hover.SetActive(hovering);
        hovering = false;
    }

    public void setHover(bool h){
        hovering = h;
    }

    public void setPrice(int i){
        string str = "" + i;
        while(str.Length<5) str = "0" + str;
        priceText.SetText(str);
    }
    public void setName(string n){
        nameText.SetText(n);
    }
    public void setImage(Sprite s){
        img.sprite = s;
    }
}
