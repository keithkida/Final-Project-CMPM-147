using UnityEngine;

public class BreakPromptUI : MonoBehaviour
{
    public static BreakPromptUI Instance;
    public GameObject text;
    public GameObject label;

    void Awake()
    {
        Instance = this;
    }

    public void Show()
    {
        text.SetActive(true);
        label.SetActive(true);
    }

    public void Hide()
    {
        text.SetActive(false);
        label.SetActive(true);
    }
}
