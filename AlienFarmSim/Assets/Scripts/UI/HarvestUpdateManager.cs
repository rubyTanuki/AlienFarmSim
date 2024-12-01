using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HarvestUpdateManager : MonoBehaviour
{
    public GameObject updatePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            addUpdate("testPlant", 2);
        }
    }

    public void addUpdate(string name, int num){
        GameObject update = Instantiate(updatePrefab);
        TextMeshProUGUI uText = update.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        uText.text = "+" + num + " " + name;
        update.transform.SetParent(this.gameObject.transform, false);

    }
}
