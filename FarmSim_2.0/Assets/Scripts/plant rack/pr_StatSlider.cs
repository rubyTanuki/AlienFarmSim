using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_StatSlider : MonoBehaviour
{
    [SerializeField] RectTransform badTransform;
    [SerializeField] RectTransform optimalTransform;
    [SerializeField] RectTransform sliderTransform;
    [SerializeField] RectTransform bgTransform;

    private float height;

    private PlantSO selectedPlant;

    void Awake()
    {
        height = 85;
    }

    public void setSlider(float val)
    {
        Vector2 targetPosition = new Vector2(sliderTransform.sizeDelta.x, val / 100.0f * height);
        sliderTransform.sizeDelta = Vector2.Lerp(sliderTransform.sizeDelta, targetPosition, Time.deltaTime * 10);
        //Vector2.Lerp(sliderTransform.sizeDelta, targetPosition, Time.deltaTime * 10);
        // val / 100 * height-44
    }

    public void setPlant(float optimal, float bad)
    {
        optimalTransform.localPosition = new Vector2(optimalTransform.localPosition.x, optimal / 100 * height -44);
        //badTransform.localPosition = new Vector2(badTransform.localPosition.x, bad / 100 * height);
        badTransform.localPosition = new Vector2(badTransform.localPosition.x, (bad / 100 * height) -44);
    }


}
