using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSelfDestroy : MonoBehaviour
{
    public float timeToDestroy = 5;

    private float startTime;

    void Awake(){
        startTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-startTime > timeToDestroy) Destroy(this.gameObject);
    }
}
