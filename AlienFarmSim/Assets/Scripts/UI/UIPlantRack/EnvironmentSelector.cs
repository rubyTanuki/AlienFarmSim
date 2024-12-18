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

    private RowUpgraderManager upgradeManager;
    private UIPRRowManager rowManager;

    private bool isHovering;
    
    // Start is called before the first frame update
    void Start()
    {
        img = spriteObject.GetComponent<Image>();
        upgradeManager = gameObject.transform.parent.parent.parent.parent.gameObject.GetComponent<RowUpgraderManager>();
        rowManager = upgradeManager.getRowManager();
    }

    // Update is called once per frame
    void Update()
    {
        if(hover.activeSelf && Input.GetMouseButtonDown(0) && rowManager.getEnvironment()!=environment){
            rowManager.setEnvironment(environment);
            inventory.subMoney(environment.getPrice());
        }

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
        img.sprite  = environment.getIcon();
    }
}
