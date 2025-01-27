using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PRPlantManager : MonoBehaviour
{


    public PlantSO plant;
    [SerializeField] private Sprite empty;
    [SerializeField] private Image plantImage;
    [SerializeField] private PRRowManager manager;

    private GameObject leafParticles;

    private float growthTimer;
    private int growthStage;

    private float disableTime;

    private bool mouseUpCheck;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(waitToInit());
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
            float growSpeed = plant.growSpeed*UnityEngine.Random.Range(.8f, 1.2f);
            while(growthTimer>growSpeed && growthStage<plant.sprites.Count-1){
                growthTimer-=growSpeed;
                growthStage++;
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
        plant = p;
    }

    public void ResetPlant(){
        HarvestPlant();
        growthTimer = 0;
        growthStage = 0;
    }

    public void HarvestPlant(){
        if(growthStage >0){
            if(plant.leafMaterial!=null)
                spawnLeafParticles();
        }
        
        plant = null;
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
        if((Input.GetMouseButton(0)||Input.GetMouseButtonDown(0)) && mouseUpCheck && !manager.zoomed){
            if(plant!=null)
                HarvestPlant();
        }
    }
}
