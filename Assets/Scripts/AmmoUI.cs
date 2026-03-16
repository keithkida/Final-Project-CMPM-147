using UnityEngine;
using TMPro;


public class AmmoUI : MonoBehaviour
{
    public static AmmoUI Instance;
    public TextMeshProUGUI ammoText;

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


    public void UpdateAmmo(int current, int max)
    {
        Debug.Log($"[AmmoUI] Received update: {current}/{max} on {gameObject.name}");
        ammoText.text = $"{current}/{max}";
    }
}
