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

    // Start is called before the first frame update
    void Awake()
    {
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
        targetRotation = new Vector3(0,0,-InputManager.mouseVelocity.x);
    }
}
