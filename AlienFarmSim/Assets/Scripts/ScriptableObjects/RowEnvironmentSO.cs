using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Row Environment", menuName = "RowEnvironmentSO")]
public class RowEnvironmentSO : RowUpgradeSO
{
    [SerializeField] private Sprite background;

    public Sprite getBackground(){return background;}
}
