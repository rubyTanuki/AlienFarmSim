using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<PlantSO> starterSeeds = new List<PlantSO>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(PlantSO p in starterSeeds){
            inventory.seedInventory.Add(p, 6);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
