using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    LootChest currentChest;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<LootChest>(out LootChest chest))
            currentChest = chest;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<LootChest>() == currentChest)
            currentChest = null;

    
        Debug.Log("Player touched: " + other.name);
    
    }

    void Update()
    {
        if (currentChest != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player opened the chest!");
            currentChest.Open();
        }
    }

}
