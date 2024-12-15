using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowUpgraderManager : MonoBehaviour
{
    [SerializeField] private UIPRRowManager rowManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public UIPRRowManager getRowManager(){
        return rowManager;
    }
}
