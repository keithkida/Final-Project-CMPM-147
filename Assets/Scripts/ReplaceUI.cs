using UnityEngine;
using TMPro;

public class ReplaceUI : MonoBehaviour
{
    public static ReplaceUI Instance;

    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI messageText;

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void Show(string message)
    {
        messageText.text = message;
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
