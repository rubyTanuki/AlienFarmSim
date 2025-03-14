using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HarvestUpdate : MonoBehaviour
{
    private float time;
    public ItemSO item;
    public int count;
    [SerializeField] private TextMeshProUGUI text;
    public HarvestUpdateManager updateManager;

    // Start is called before the first frame update
    void Start()
    {
        updateManager = GameObject.Find("UICanvas/HarvestUpdates").GetComponent<HarvestUpdateManager>();
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(item != null){
            text.SetText("+" + count + " " + item.name);
        }
        
        if(Time.time-time>2){
            updateManager.updateList.Remove(item);
            Destroy(this.gameObject);
        }
    }

    public void resetTimer(){
        if(Time.time-time>1){
            time = Time.time+1;
        }
    }

}
