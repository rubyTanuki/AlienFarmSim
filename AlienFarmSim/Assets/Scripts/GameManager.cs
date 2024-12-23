using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static readonly float ITEM_BUY_MULTIPLIER = 2.5f;

    public static Stack<Action> closes = new Stack<Action>();

    public static PlanetSO currentPlanet;


    [SerializeField] private List<PlantSO> starterSeeds = new List<PlantSO>();
    [SerializeField] private List<CropSO> starterCrops = new List<CropSO>();
    [SerializeField] private List<RowEnvironmentSO> starterEnvs = new List<RowEnvironmentSO>();
    public Scene startScene;
    // Start is called before the first frame update
    void Awake()
    {
        //SceneManager.LoadScene("TestRoom", LoadSceneMode.Additive);
        foreach(PlantSO p in starterSeeds){
            inventory.seedInventory.Add(p, 6);
        }
        foreach(CropSO c in starterCrops){
            inventory.cropInventory.Add(c, 10);
        }
        foreach(RowEnvironmentSO env in starterEnvs){
            inventory.addFabricatorModule(env);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            if(closes.Count!=0){
                exitCurrentUIOpen();
            }else{
                openSettings();
            }
        }
    }

    public static void addToCloses(Action a){
        closes.Push(a);
    }


    public void exitCurrentUIOpen(){
        Action a = closes.Pop();
        //Debug.Log(a.Method.Name);
        a();
    }

    public void openSettings(){

    }

    public static void setCurrentPlanet(PlanetSO p){
        currentPlanet = p;
    }
}
