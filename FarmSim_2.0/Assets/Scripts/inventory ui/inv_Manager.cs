using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inv_Manager : MonoBehaviour
{
    [SerializeField] RectTransform listTransform;
    [SerializeField] GameObject itemSelectorPrefab;



    public void PopulateCrops()
    {
        clearList();
        foreach (CropSO crop in inventorySingleton.inv.cropInventory.Keys)
        {
            GameObject slot = Instantiate(itemSelectorPrefab, listTransform);
            slot.GetComponent<inv_ItemSelector>().SetItem(crop);
        }
    }
    public void PopulateSeeds()
    {
        clearList();
        foreach (SeedSO seed in inventorySingleton.inv.seedInventory.Keys)
        {
            GameObject slot = Instantiate(itemSelectorPrefab, listTransform);
            slot.GetComponent<inv_ItemSelector>().SetItem(seed);
        }
    }
    public void PopulateItems()
    {
        clearList();
        foreach (ItemSO item in inventorySingleton.inv.itemInventory.Keys)
        {
            GameObject slot = Instantiate(itemSelectorPrefab, listTransform);
            slot.GetComponent<inv_ItemSelector>().SetItem(item);
        }
    }

    private void clearList()
    {
        for (int i = listTransform.childCount - 1; i >= 0; i--)
        {
            Destroy(listTransform.GetChild(i).gameObject);
        }
    }
}
