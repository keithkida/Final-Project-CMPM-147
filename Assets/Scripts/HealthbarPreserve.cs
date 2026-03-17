using UnityEngine;

public class HealthBarPreserve : MonoBehaviour
{
    public static HealthBarPreserve Instance;

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
