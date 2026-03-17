using UnityEngine;

public class StatusWindowPreserve : MonoBehaviour
{
    public static StatusWindowPreserve Instance;

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
