using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_StatsManager : MonoBehaviour
{
    [SerializeField] private PRManager rackManager;
    [SerializeField] private pr_StatSlider waterSlider;
    [SerializeField] private pr_StatSlider lightSlider;
    [SerializeField] private pr_StatSlider nitrogenSlider;
    [SerializeField] private pr_StatSlider phosphorusSlider;
    [SerializeField] private pr_StatSlider oxygenSlider;


    void Update()
    {
        if (rackManager.selectedRow != null)
        {
            UpdatePlant();
            UpdateStats();
        }
        
    }

    public void UpdatePlant()
    {
        
        pr_rowManager row = rackManager.selectedRow.GetComponent<pr_rowManager>();
        if (row.plant == null) return;
        waterSlider.setPlant(row.plant.optimalStats[0], row.plant.badStats[0]);
        lightSlider.setPlant(row.plant.optimalStats[1], row.plant.badStats[1]);
        nitrogenSlider.setPlant(row.plant.optimalStats[2], row.plant.badStats[2]);
        phosphorusSlider.setPlant(row.plant.optimalStats[3], row.plant.badStats[3]);
        oxygenSlider.setPlant(row.plant.optimalStats[4], row.plant.badStats[4]);
    }
    public void UpdateStats()
    {
        pr_rowManager row = rackManager.selectedRow.GetComponent<pr_rowManager>();
        waterSlider.setSlider(row.water);
        lightSlider.setSlider(row.light);
        nitrogenSlider.setSlider(row.nitrogen);
        phosphorusSlider.setSlider(row.phosphorus);
        oxygenSlider.setSlider(row.oxygen);
    }
}
