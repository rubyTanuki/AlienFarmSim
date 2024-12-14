using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnvironmentSelector : MonoBehaviour
{
    [SerializeField] private GameObject hover;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private GameObject spriteObject;
    private Image img;

    private RowEnvironmentSO environment;

    private bool isHovering;
    
    // Start is called before the first frame update
    void Start()
    {
        img = spriteObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hover.SetActive(isHovering);
        isHovering = false;
    }

    public void setHover(bool b){ isHovering = b;}

    public void setEnvironment(RowEnvironmentSO env){
        environment = env;
        nameText.SetText(environment.getName());
        string text = "" + environment.getPrice();
        while(text.Length<5) text = "0" + text;
        priceText.SetText(text);
        img = environment.getIcon();
    }
}
