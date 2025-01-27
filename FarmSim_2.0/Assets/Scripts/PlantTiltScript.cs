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

    private readonly float TILT_SPEED = .5f;

    private GameObject leafParticles;

    // Start is called before the first frame update
    void Awake()
    {
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
            rectTransform.eulerAngles = new Vector3(0,0,rectTransform.eulerAngles.z+tiltNum);

            if(Mathf.Abs(targetRotation.z) - Mathf.Abs(rectTransform.eulerAngles.z)<5) tilting = false;
            
        }else{
            float reductionNum = -Mathf.Max(4*Time.deltaTime, Mathf.Abs(targetRotation.z*Time.deltaTime*DAMPEN_SPEED));
            
            targetRotation = new Vector3(0,0,targetRotation.z>0?targetRotation.z+reductionNum:targetRotation.z-reductionNum);
            rectTransform.eulerAngles = targetRotation;
        }
        
        
    }

    public void Tilt(){
        tilting = true;
        targetRotation = new Vector3(0,0,-InputManager.mouseVelocity.x*.6f);
        if(gameObject.transform.parent.GetComponent<PRPlantManager>().plant != null && 
            Mathf.Abs(InputManager.mouseVelocity.x)>1)
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
