using UnityEngine;


public class PlayerPersistence : MonoBehaviour
{
    public static PlayerPersistence Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void ResetPlayer()
    {
        var stats = Object.FindAnyObjectByType<PlayerStats>();
        if (stats != null)
        {
            stats.ResetStats();
        }

        var inventory = Object.FindAnyObjectByType<PlayerAttackController>();
        if (inventory != null)        {
            inventory.ResetInventory();
        }

        var healthUI = Object.FindAnyObjectByType<HealthUI>();
        if (healthUI != null)
        {
            healthUI.ResetUI();
        }

        var inventoryUI = Object.FindAnyObjectByType<InventoryUI>();
        if (inventoryUI != null)
        {
            inventoryUI.ResetUI();
        }

    }

}
