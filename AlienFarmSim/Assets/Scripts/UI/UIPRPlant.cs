using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPRPlant : MonoBehaviour
{

    private double timer;
    private Sprite activeSprite;
    public PlantSO plant;
    private int growthStage = 0;

    private enum Stages
    {
        Seedling,
        Sprout,
        Juvenile,
        Mature,
        Ripe,
        Overripe
    }

    private Sprite empty;
    // Start is called before the first frame update
    void Start()
    {
        resetTimer();
        empty = GetComponent<Image>().sprite;
        if(plant!=null) activeSprite = plant.sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(plant == null){
            Image img = GetComponent<Image>();
            img.sprite = empty;
            return;
        }

        if(plant != null && shouldGrow()){
            growthStage += 1;
            activeSprite = plant.sprites[growthStage];
            Image img = GetComponent<Image>();
            img.sprite = activeSprite;
            increaseTimer();
        }
    }

    public Sprite getImage(){
        Image img = GetComponent<Image>();
        return img.sprite;
    }

    public void resetTimer(){
        timer = Time.time;
    }
    public void increaseTimer(){
        timer += plant.growthTime;
    }

    public void resetPlant(){
        growthStage = 0;
        resetTimer();
        Image img = GetComponent<Image>();
        if(plant != null){
            activeSprite = plant.sprites[0];
            img.sprite = activeSprite;
        }
    }
    public void setPlant(PlantSO p){
        plant = p;
    }

    private bool shouldGrow(){
        return Time.time-timer>plant.growthTime && growthStage != plant.sprites.Length-1;
    }
}
