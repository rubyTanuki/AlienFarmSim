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
    public List<GameObject> rooms = new List<GameObject>();

    public static int currentRoom;
    private GameObject activeRoom;
    public GameObject mainRoom;

    public GameObject navManager;

    [Header("Starter Inventory")]
    [SerializeField] private List<PlantSO> starterSeeds = new List<PlantSO>();
    [SerializeField] private List<CropSO> starterCrops = new List<CropSO>();
    [SerializeField] private List<RowEnvironmentSO> starterEnvs = new List<RowEnvironmentSO>();
    public Scene startScene;


    private static Camera mainCamera;

    private static float cameraTargetX;
    private static float cameraTargetSize;



    // Start is called before the first frame update
    void Awake()
    {
        activeRoom = mainRoom;
        setCameraSizeTarget(6);
        setCameraTarget(0);
        setCurrentRoom(0);

        mainCamera = Camera.main;
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
        if(Input.GetKeyDown(KeyCode.P)){
            if(currentRoom ==1)
                setCurrentRoom(0);
            else
                setCurrentRoom(1);
        } 

        if(Input.GetKeyDown("escape")){
            if(closes.Count!=0){
                exitCurrentUIOpen();
            }else{
                openSettings();
            }
        }
        //if(closes.Count == 0)
        if(!navManager.activeSelf)
            lerpToTarget();
    }

    public static void addToCloses(Action a){
        closes.Push(a);
        //Debug.Log("adding " + a.Method.Name + " to closes");
    }


    public void exitCurrentUIOpen(){
        Action a = closes.Pop();
       // Debug.Log("closing with " + a.Method.Name);
        a();
    }

    public void openSettings(){

    }

    public void setCurrentRoom(int i){
        if(currentRoom!=i){
            rooms[currentRoom].GetComponent<BlastDoorScript>().enabled = false;
            currentRoom = i;
            rooms[currentRoom].GetComponent<BlastDoorScript>().enabled = true;
        }
    }

    public static void setCurrentPlanet(PlanetSO p){
        currentPlanet = p;
    }

    public void setCameraTarget(float t){
        cameraTargetX = t;
    }
    public void setCameraSizeTarget(float t){
        cameraTargetSize = t;
    }

    public void lerpToTarget(){
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, cameraTargetSize, 10*Time.deltaTime);
        Vector2 targetPos = new Vector3(cameraTargetX, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPos, 5*Time.deltaTime);
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, -10);
    }

    // public void decreaseCurrentRoom(){
    //     int num = currentRoom;
    //     num--;
    //     if(num<0) num = rooms.Count-1;
    //     setCurrentRoom(num);
    // }

    // public void increaseCurrentRoom(){
    //     int num = currentRoom;
    //     num++;
    //     if(num>=rooms.Count) num = 0;
    //     setCurrentRoom(num);
    // }

    // public static void setActiveRoom(GameObject room){
    //     if(activeRoom!=null) Destroy(activeRoom);
    //     activeRoom = Instantiate(room);
    // }

    public void setActiveRoom(GameObject room){
        activeRoom.SetActive(false);
        activeRoom = room;
        activeRoom.SetActive(true);
        GameManager.addToCloses(leaveRoom);
    }

    public void leaveRoom(){
        activeRoom.SetActive(false);
        activeRoom = mainRoom;
        activeRoom.SetActive(true);
    }


}
