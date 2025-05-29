using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSettingsManager : MonoBehaviour
{

    public GameObject plantPanel;
    public GameObject potPanel;
    public GameObject button;
    private RectTransform buttonTransform;

    public PRManager currentPR;

    private bool plantIsOpen;

    private readonly float BUTTON_LEFT_X = -67.5f;
    private readonly float BUTTON_RIGHT_X = 67.5f;
    private readonly float BUTTON_LERP_SPEED = 2000;

    private Vector2 buttonTarget = new Vector2();

    // Start is called before the first frame update
    void Awake()
    {
        buttonTransform = button.GetComponent<RectTransform>();
        buttonTransform.anchoredPosition = new Vector3(buttonTransform.anchoredPosition.x, buttonTransform.anchoredPosition.y, -67.5f);
        buttonTarget = buttonTransform.anchoredPosition;
        openPlantPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if(plantIsOpen && buttonTransform.anchoredPosition.x>BUTTON_LEFT_X){
            buttonTransform.anchoredPosition = new Vector2(buttonTransform.anchoredPosition.x - BUTTON_LERP_SPEED*Time.deltaTime, buttonTransform.anchoredPosition.y);
        }else if(!plantIsOpen && buttonTransform.anchoredPosition.x<BUTTON_RIGHT_X){
            buttonTransform.anchoredPosition = new Vector2(buttonTransform.anchoredPosition.x + BUTTON_LERP_SPEED*Time.deltaTime, buttonTransform.anchoredPosition.y);
        }

        //buttonTransform.anchoredPosition = Vector3.Lerp(buttonTransform.anchoredPosition, buttonTarget, BUTTON_LERP_SPEED*Time.deltaTime);
    }

    public void Swap(){
        if(!plantIsOpen){
            openPlantPanel();
        }else{
            openPotPanel();
        }
    }

    private void openPlantPanel(){
        plantIsOpen = true;
        //buttonTarget.z = BUTTON_LEFT_Z;
        buttonTarget = new Vector2(BUTTON_LEFT_X, buttonTransform.anchoredPosition.y);
        potPanel.SetActive(false);
        plantPanel.SetActive(true);        
    }

    private void openPotPanel(){
        plantIsOpen = false;
        //buttonTarget.z = BUTTON_RIGHT_Z;
        buttonTarget = new Vector2(BUTTON_RIGHT_X, buttonTransform.anchoredPosition.y);
        potPanel.SetActive(true);
        plantPanel.SetActive(false);
    }

    public void PlantInSelectedRow(PlantSO plant){
        currentPR.selectedRow.GetComponent<pr_rowZoomed>().PlantAll(plant);
        
    }
}
