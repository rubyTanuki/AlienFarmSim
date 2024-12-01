using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlantSO", menuName = "PlantSO")]
public class PlantSO : ItemSO
{
    public double growthTime;
    public Sprite[] sprites;
    public CropSO crop;
}
