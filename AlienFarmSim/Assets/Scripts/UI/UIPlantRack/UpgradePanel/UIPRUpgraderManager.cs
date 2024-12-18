using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPRUpgraderManager : MonoBehaviour
{

    [SerializeField] GameObject rowMenu;
    [SerializeField] GameObject slotMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void closeAll(){
        rowMenu.SetActive(false);
        slotMenu.SetActive(false);
    }

    public void openRowMenu(){
        closeAll();
        rowMenu.SetActive(true);
    }

    public void openSlotMenu(){
        closeAll();
        slotMenu.SetActive(true);
    }
}
