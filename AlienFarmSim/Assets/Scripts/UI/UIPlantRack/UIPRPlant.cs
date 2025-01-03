using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPRPlant : MonoBehaviour
{

    private double timer;
    private Sprite activeSprite;
    public PlantSO plant;
    public int growthStage = 0;

    private float growthRate;

    public enum Stages
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
            resetTimer();
            growthRate *= Random.Range(0.9f, 1.1f);
            growthRate = Mathf.Clamp(growthRate, (float)plant.growthTime*.75f, (float)plant.growthTime*1.25f);
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
        growthRate = (float)plant.growthTime * Random.Range(0.8f, 1.2f);
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
        return Time.time-timer>growthRate && growthStage != plant.sprites.Length-1;
    }
}
