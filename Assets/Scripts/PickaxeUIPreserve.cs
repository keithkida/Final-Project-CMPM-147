using UnityEngine;

public class PickaxeUIPreserve : MonoBehaviour
{
    public static PickaxeUIPreserve Instance;

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

