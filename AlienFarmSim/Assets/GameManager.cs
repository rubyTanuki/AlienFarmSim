using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static readonly float ITEM_BUY_MULTIPLIER = 2.5f;




    [SerializeField] private List<PlantSO> starterSeeds = new List<PlantSO>();
    public Scene startScene;
    // Start is called before the first frame update
    void Awake()
    {
        //SceneManager.LoadScene("TestRoom", LoadSceneMode.Additive);
        foreach(PlantSO p in starterSeeds){
            inventory.seedInventory.Add(p, 6);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
