using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class util_invUpdate : MonoBehaviour
{
    private float time;
    public ItemSO item;
    public int count;

    private readonly float lifetime = 2f;
    [SerializeField] private TextMeshProUGUI text;
    public util_invUpdateManager updateManager;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(item != null){
            text.SetText("+" + count + " " + item);
        }
        
        if(Time.time-time>lifetime){
            updateManager.updateList.Remove(item);
            Destroy(this.gameObject);
        }
    }

    public void resetTimer(){
        //add once second to life if been alive for less than 1 second
        if(Time.time-time<1){
            time = Time.time+1;
        }
    }

    public float GetAge(){
        return Time.time-time;
    }
}
