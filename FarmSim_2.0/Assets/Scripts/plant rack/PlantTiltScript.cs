using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantTiltScript : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 targetRotation = new Vector3(0,0,0);
    private bool tilting;
    private readonly float DAMPEN_SPEED = 8;

    private readonly float TILT_SPEED = .05f;

    private GameObject leafParticles;

    public pr_rowManager rowManager;

    // Start is called before the first frame update
    void Awake()
    {
        //rowManager = this.transform.parent.parent.parent.GetComponent<pr_rowManager>();
        leafParticles = Resources.Load<GameObject>("ParticleSystems/LeafParticles_small");
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
         //Vector3.Lerp(rectTransform.eulerAngles, targetRotation, 5*Time.deltaTime);

        if(tilting){

            // rectTransform.eulerAngles = new Vector3(0,0,rectTransform.eulerAng)
            float tiltNum = TILT_SPEED*Time.deltaTime * targetRotation.z>0?1:-1;
            tiltNum*=.2f;
            rectTransform.eulerAngles = new Vector3(0,0,rectTransform.eulerAngles.z+tiltNum);

            if(Mathf.Abs(targetRotation.z) - Mathf.Abs(rectTransform.eulerAngles.z)<5) tilting = false;
            
        }else{
            float reductionNum = -Mathf.Max(4*Time.deltaTime, Mathf.Abs(targetRotation.z*Time.deltaTime*DAMPEN_SPEED));
            reductionNum*=.8f;
            targetRotation = new Vector3(0,0,targetRotation.z>0?targetRotation.z+reductionNum:targetRotation.z-reductionNum);
            rectTransform.eulerAngles = targetRotation;
        }
    }

    public void Tilt(){
        if (rowManager.zoom && rowManager.isSelectedRow()) return;
        if ((!rowManager.zoom || rowManager.isSelectedRow()) && gameObject.transform.parent.GetComponent<PRPlantManager>().growthStage > 0)
        {
            tilting = true;
            float range = .25f;
            float randomMulti = Random.Range(1f - range, 1f + range);
            // Debug.Log(-InputManager.mouseVelocity.x*.6f*randomMulti);
            float clampedTarget = Mathf.Clamp(-InputManager.mouseVelocity.x * .6f * randomMulti, -10, 10);
            targetRotation = new Vector3(0, 0, clampedTarget);
            if (gameObject.transform.parent.GetComponent<PRPlantManager>().plant != null &&
                gameObject.transform.parent.GetComponent<PRPlantManager>().growthStage >= 2 &&
                Mathf.Abs(InputManager.mouseVelocity.x) > 1)
                spawnLeafParticles();
        }
    }

    public void Wobble(){
        tilting = true;
        int range = 10;
        float random = Random.Range(-1f, 1f);
        targetRotation = new Vector3(0,0,random>0?range:-range);
        if(gameObject.transform.parent.GetComponent<PRPlantManager>().plant != null)
            spawnLeafParticles();
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
        renderer.material = gameObject.transform.parent.GetComponent<PRPlantManager>().plant.leafMaterial;
        particles.transform.SetParent(this.gameObject.transform.parent);
        particles.transform.localScale = new Vector3(.6f, .6f, 1);
        
        Vector3 pos = transform.position;
        pos.y = pos.y + ((rectTransform.sizeDelta.y)/128);
        particles.transform.position = pos;
    }
}
