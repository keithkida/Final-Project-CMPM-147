using UnityEngine;
using TMPro;


public class AmmoUI : MonoBehaviour
{
    public static AmmoUI Instance;
    public TextMeshProUGUI ammoText;

    void Awake()
    {
        Debug.Log($"[AmmoUI] Awake on object: {gameObject.name}");
        Instance = this;
    }

    public void UpdateAmmo(int current, int max)
    {
        Debug.Log($"[AmmoUI] Received update: {current}/{max} on {gameObject.name}");
        ammoText.text = $"{current}/{max}";
    }
}
