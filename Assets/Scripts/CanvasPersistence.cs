using UnityEngine;

public class CanvasPersistence : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
