using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject envSlotPrefab;
    [SerializeField] UIPRManager rackManager;
    

    private Dictionary<RowEnvironmentSO, GameObject> envSlots = new Dictionary<RowEnvironmentSO, GameObject>();
    

    void OnEnable(){
        StartCoroutine(updateSlots());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator updateSlots(){
        for(int i=0;i<1;i++){
            yield return null;
        }
        //Debug.Log("Updating with length of " + inventory.environmentModules.Count);

        foreach(RowEnvironmentSO so in inventory.environmentModules){
            if(envSlots.ContainsKey(so)){
                envSlots[so].GetComponent<EnvUpgradeMenuOption>().updateInfo();
            }else{
                instantiateSlot(so);
            }
        }
    }

    public void instantiateSlot(RowEnvironmentSO so){
        //Debug.Log("Instantiating Slot for " + so);
        GameObject slot = Instantiate(envSlotPrefab);
        slot.transform.SetParent(content.transform);
        slot.transform.localScale = new Vector3(1,1,1);
        slot.transform.position = new Vector3(slot.transform.position.x, slot.transform.position.y, 0);
        EnvUpgradeMenuOption script = slot.GetComponent<EnvUpgradeMenuOption>();
        script.manager = this;
        script.setEnvironment(so);
        envSlots.Add(so, slot);
        var button = slot.GetComponent<Button>();
        button.onClick.AddListener(delegate {this.applyEnvironment(so);});
    }

    public void applyEnvironment(RowEnvironmentSO env){
        rackManager.selectedRow.GetComponent<UIPRRowManager>().setEnvironment(env);
    }

}
