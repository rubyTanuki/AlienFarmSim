using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlanetSO", menuName = "PlanetSO")]
public class PlanetSO : ScriptableObject
{
    //[SerializeField] private string name;
    public string Name {get;}

    [SerializeField] private string description;
    public string Description {get;}

    [SerializeField] private Sprite lowres_image;
    public Sprite getLowResImage(){return lowres_image;}
    [SerializeField] private Sprite highres_image;
    public Sprite getHighResImage(){return highres_image;}


    private bool inhabitable;
    public bool Inhabitable {get;}
}
