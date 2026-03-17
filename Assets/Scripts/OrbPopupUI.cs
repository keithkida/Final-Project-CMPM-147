using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrbPopupUI : MonoBehaviour
{
    public static OrbPopupUI Instance;

    public GameObject panel;           
    public TextMeshProUGUI nameText;  
    public TextMeshProUGUI descText;  
    public Image icon;                

    void Start()
    {
        panel.SetActive(false);
    }

    void Awake()
    {
        Instance = this;
    }

    public void Show(Orb orb)
    {
        nameText.text = orb.orbName;
        descText.text = orb.description;

        if (icon != null)
            icon.sprite = orb.GetComponent<SpriteRenderer>().sprite;

        panel.SetActive(true);

    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
