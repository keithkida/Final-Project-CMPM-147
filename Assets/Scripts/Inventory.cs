using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<LootChest.gameItem> items = new List<LootChest.gameItem>();
    int maxItems = 12;

    public bool AddItem(LootChest.gameItem item)
    {
        if (items.Count < maxItems)
        {
            items.Add(item);
            return true;
        }
        else
        {
            Debug.Log("Inventory is full!");
            return false;
        }
    }
}
