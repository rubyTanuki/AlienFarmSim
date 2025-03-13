using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlantSO", menuName = "PlantSO")]
public class PlantSO : ScriptableObject
{
    public float growSpeed;

    public string extendedName;
    public string description;

    public SeedSO seed;

    public List<Sprite> sprites = new List<Sprite>();

    public List<ItemSO> harvestItems = new List<ItemSO>();
    public List<int> harvestItemNumsMax = new List<int>();
    public List<int> harvestItemNumsMin = new List<int>();

    public Material leafMaterial;
}
