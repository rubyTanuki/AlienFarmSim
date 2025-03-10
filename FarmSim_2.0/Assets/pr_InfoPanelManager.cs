using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pr_InfoPanelManager : MonoBehaviour
{
    public Image plantImage;
    public Image seedImage;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public FlipNumberScript flipNum;


    public PlantSO selectedPlant;

    public PlantSO nullPlant;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedPlant != null){
            flipNum.gameObject.SetActive(true);
            title.text = selectedPlant.extendedName;
            description.text = selectedPlant.description;
            plantImage.sprite = selectedPlant.sprites[4];
            plantImage.SetNativeSize();
            seedImage.sprite = selectedPlant.seed.seedPackage;
            seedImage.SetNativeSize();
            seedImage.gameObject.transform.localScale = new Vector2(2, 2);
            flipNum.SetNum(inventorySingleton.inv.seedInventory[selectedPlant.seed]);
            //flipNum.SetNum(99);

        }else{
            flipNum.gameObject.SetActive(false);
            title.text = nullPlant.extendedName;
            description.text = nullPlant.description;
            plantImage.sprite = nullPlant.sprites[0];
            seedImage.sprite = nullPlant.sprites[3];
            
        }
        
    }

    public void setPlant(PlantSO p){
        selectedPlant = p;
    }
}
