using UnityEngine;

public class NumericalHealthPreserve : MonoBehaviour
{
    public static NumericalHealthPreserve Instance;

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


