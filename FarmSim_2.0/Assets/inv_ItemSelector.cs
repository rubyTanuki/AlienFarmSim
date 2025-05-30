using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inv_ItemSelector : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private FlipNumberScript num;
    public ItemSO item;

    void init()
    {
        img.sprite = item.image;
        name.SetText(item.toString());
        
    }

    void Update()
    {
        if (item == null) return;
        num.SetNum(inventorySingleton.inv.Get(item));
        // int invAmt = inventorySingleton.inv.Get(item);
        // if(num.currentNum!=invAmt) num.SetNum(invAmt);

        //if (!inventorySingleton.inv.Contains(item)) Destroy(this.gameObject);
    }

    public void SetItem(ItemSO i)
    {
        item = i;
        init();
    }
}
