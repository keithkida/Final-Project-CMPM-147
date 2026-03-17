using UnityEngine;
using TMPro;

public class NoWeaponUI : MonoBehaviour
{
    public static NoWeaponUI Instance;

    public GameObject label;
    public TextMeshProUGUI meleeText;
    public TextMeshProUGUI rangedText;

    void Start()
    {
        label.SetActive(false);
        meleeText.gameObject.SetActive(false);
        rangedText.gameObject.SetActive(false);
    }

    void Awake()
    {
        Instance = this;
    }

    public void ShowMelee()
    {
        label.SetActive(true);
        meleeText.gameObject.SetActive(true);
        rangedText.gameObject.SetActive(false);

        CancelInvoke();
        Invoke(nameof(Hide), 1.5f);
    }

    public void ShowRanged()
    {
        label.SetActive(true);
        meleeText.gameObject.SetActive(false);
        rangedText.gameObject.SetActive(true);

        CancelInvoke();
        Invoke(nameof(Hide), 1.5f);
    }

    public void Hide()
    {
        label.SetActive(false);
        meleeText.gameObject.SetActive(false);
        rangedText.gameObject.SetActive(false);
    }
}
