using UnityEngine;

public class InventoryPreserve : MonoBehaviour
{
    public static InventoryPreserve Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
