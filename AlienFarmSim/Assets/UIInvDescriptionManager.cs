using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInvDescriptionManager : MonoBehaviour
{
    [SerializeField] private GameObject imageObject;
    private Sprite img;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI info;
    [SerializeField] private GameObject stats;

    [SerializeField] private GameObject statPrefab;

    private ItemSO item;
    private UIInvManager manager;
    // Start is called before the first frame update
    void Start()
    {
        img = imageObject.GetComponent<Image>().sprite;
        manager = GameObject.Find("UICanvas/InventoryUI").GetComponent<UIInvManager>();
        item = manager.selectedItem;
        if(item!=null){
            name.SetText(item.name);
            info.SetText(item.description);
            imageObject.GetComponent<Image>().sprite = item.image;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.selectedItem != null && manager.selectedItem != item){
            item = manager.selectedItem;
            name.SetText(item.name);
            info.SetText(item.description);
            imageObject.GetComponent<Image>().sprite = item.image;
        }
    }
}
