using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlotMenuOption : MonoBehaviour
{
    [SerializeField] private GameObject hover;
    private bool hovering;


    private PlantSO seed;
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private GameObject imgObj;
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = imgObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        hover.SetActive(hovering);
        hovering = false;
    }

    public void setHover(bool h){ hovering = h;}

    public void setSeed(PlantSO s){
        seed = s;
    }
    public void setCount(int c){
        string str = "" + c;
        while (str.Length<3) str = "0" + str;
        count.SetText(str);
    }
    public void setImage(Sprite s){
        img.sprite = s;
    }


}
