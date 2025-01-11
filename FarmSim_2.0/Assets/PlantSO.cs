using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlantSO", menuName = "PlantSO")]
public class PlantSO : ScriptableObject
{
    public float growSpeed;

    public List<Sprite> sprites = new List<Sprite>();

    public Material leafMaterial;
}
