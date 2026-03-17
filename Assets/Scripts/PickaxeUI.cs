using UnityEngine;
using TMPro;

public class PickaxeUI : MonoBehaviour
{
    public static PickaxeUI Instance;

    public GameObject root;
    public GameObject panel;
    public GameObject image;
    public TextMeshProUGUI usesText;

    void Start()
    {
        root.SetActive(false);
        panel.SetActive(false);
        image.SetActive(false);
    }

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

    public void Show(int uses)
    {
        root.SetActive(true);
        panel.SetActive(true);
        image.SetActive(true);
        usesText.text = "Uses: " + uses;
    }

    public void UpdateUses(int uses)
    {
        usesText.text = "Uses: " + uses;
    }

    public void Hide()
    {
        root.SetActive(false);
        panel.SetActive(false);
        image.SetActive(false);
    }
}
