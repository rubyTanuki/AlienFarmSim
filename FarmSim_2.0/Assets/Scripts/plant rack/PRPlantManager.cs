using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PRPlantManager : MonoBehaviour
{


    public PlantSO plant;
    [SerializeField] private Sprite empty;
    [SerializeField] private Image plantImage;
    private pr_rowManager manager;

    [SerializeField] private PlantTiltScript tiltScript;

    private GameObject leafParticles;

    private float growthTimer;
    public int growthStage;

    private float growSpeed;

    private float disableTime;
    private float lastEnable = 0;

    private bool mouseUpCheck;

    // Start is called before the first frame update
    void Awake()
    {
        growSpeed = plant.growSpeed*UnityEngine.Random.Range(.6f, 1.4f);
        StartCoroutine(waitToInit());
        manager = transform.parent.parent.GetComponent<pr_rowManager>();
        leafParticles = Resources.Load<GameObject>("ParticleSystems/LeafParticles");
        if(plant!=null)
            SetPlant(plant);
        disableTime = Time.time;
    }

    private IEnumerator waitToInit(){
        yield return null;
    }

    void OnEnable()
    {
        lastEnable = Time.time;
        mouseUpCheck = false;
        growthTimer += Time.time - disableTime;
    }

    void OnDisable(){
        disableTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetMouseButton(0)) mouseUpCheck=true;
        if(plant==null){
            plantImage.sprite = empty;
        }else{
            growthTimer += Time.deltaTime;
            
            while(growthTimer>growSpeed && growthStage<plant.sprites.Count-1){
                growthTimer-=growSpeed;
                growthStage++;
                //psuedorandom flip using time.time
                Vector3 scale = plantImage.gameObject.GetComponent<RectTransform>().localScale;
                plantImage.gameObject.GetComponent<RectTransform>().localScale = new Vector3(((int)(Time.time*100))%2==0?scale.x:-scale.x, scale.y, scale.z);
                //randomizing growth speed
                growSpeed = plant.growSpeed*UnityEngine.Random.Range(.6f, 1.4f);
                //only send trigger for particles if on screen when growth happened
                if(Time.time-lastEnable>.2f){
                    tiltScript.Wobble();
                }
                
            }

            plantImage.sprite = plant.sprites[growthStage];
            StartCoroutine(setNativeSize());
        }
    }

    private IEnumerator setNativeSize(){
        yield return null;
        plantImage.SetNativeSize();
    }

    public void SetPlant(PlantSO p){
        ResetPlant();
        //inventorySingleton.inv.AddItemToInventory(plant.seed);
        plant = p;
    }

    public void ResetPlant(){
        HarvestPlant();
    }

    public void HarvestPlant(){
        if(plant!=null){
            if(growthStage >0){
                //harvesting logic (add stuff to inv)
                if(growthStage==plant.sprites.Count-1){
                    inventorySingleton inv = inventorySingleton.inv;
                    
                    for(int i=0;i<plant.harvestItems.Count;i++){
                        //add item to inv based on amt of 
                        ItemSO item = plant.harvestItems[i];
                        int amt = Random.Range(plant.harvestItemNumsMin[i], plant.harvestItemNumsMax[i]+1);
                        if(item is SeedSO seed){
                            inv.AddItemToInventory(seed, amt);
                        }else if(item is CropSO crop){
                            inv.AddItemToInventory(crop, amt);
                        }else{
                            inv.AddItemToInventory(item, amt);
                        }
                        //inv.AddItemToInventory(plant.harvestItems[i], Random.Range(plant.harvestItemNumsMin[i], plant.harvestItemNumsMax[i]+1));
                    }
                }
                //spawning particles
                if(plant.leafMaterial!=null)
                    spawnLeafParticles();
            }
            //resetting plant to seed
            growthTimer = 0;
            growthStage = 0;
        }
    }

    private void spawnLeafParticles(){
        GameObject particles = Instantiate(leafParticles);
        ParticleSystem particleSystem = particles.GetComponent<ParticleSystem>();
        var shape = particleSystem.shape;
        if(InputManager.mouseVelocity.x <-1){
            shape.position = new Vector3(0.6f, 0, 0);
            shape.rotation = new Vector3(-15, -90, 0);
        }else if(InputManager.mouseVelocity.x >1){
            shape.position = new Vector3(-0.6f, 0, 0);
            shape.rotation = new Vector3(-15, 90, 0);
        }else{
            shape.position = new Vector3(0, 0, 0);
            shape.rotation = new Vector3(-15, 0, 0);
        }
        var renderer = particleSystem.GetComponent<Renderer>();
        renderer.material = plant.leafMaterial;
        particles.transform.SetParent(this.gameObject.transform);
        particles.transform.localScale = new Vector3(.6f, .6f, 1);

        GameObject plantObj = plantImage.gameObject;
        Vector3 pos = plantObj.transform.position;
        pos.y = pos.y + ((plantObj.GetComponent<RectTransform>().sizeDelta.y)/128);
        particles.transform.position = pos;
    }

    public void OnMouseOver(){
        if((Input.GetMouseButton(0)||Input.GetMouseButtonDown(0)) && mouseUpCheck && !manager.zoom){
            if(plant!=null)
                HarvestPlant();
        }
    }
}
