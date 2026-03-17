using UnityEngine;
using TMPro;

public class NoPickaxeUI : MonoBehaviour
{
    public static NoPickaxeUI Instance;

    public GameObject label;
    public GameObject message;

    void Start()
    {
        label.SetActive(false);
        message.SetActive(false);
    }

    void Awake()
    {
        Instance = this;
    }

    public void Show()
    {
        label.SetActive(true);
        message.SetActive(true);
        Invoke(nameof(Hide), 1.5f);
    }

    public void Hide()
    {
        label.SetActive(false);
        message.SetActive(false);
    }
}
