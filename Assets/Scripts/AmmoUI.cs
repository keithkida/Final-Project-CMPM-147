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

    public void Show()
    {
        ammoText.gameObject.SetActive(true);
    }

    public void Hide()
    {
        ammoText.gameObject.SetActive(false);
    }

    public void ResetAmmo()
    {
        ammoText.text = "0/0";
    }
}
