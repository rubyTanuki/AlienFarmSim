using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRSlotManager : MonoBehaviour
{
    private PRRowManager rowManager;

    [SerializeField] private GameObject selected;

    // Start is called before the first frame update
    void Awake()
    {
        rowManager = this.transform.parent.gameObject.GetComponent<PRRowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        selected.SetActive(this.gameObject == rowManager.selectedSlot);
    }

    public void Select(){

    }
}
