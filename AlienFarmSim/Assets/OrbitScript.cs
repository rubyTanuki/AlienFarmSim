using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public float orbitSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(0,0,Random.Range(0,360));
    }

    // Update is called once per frame
    void Update()
    {
        // float rotationAngle = transform.rotation.z + (orbitSpeed * 100 * Time.deltaTime);
        // transform.rotation = Quaternion.Euler(0,0,rotationAngle);
        transform.Rotate(0,0,orbitSpeed*Time.deltaTime *.2f);
    }
}
