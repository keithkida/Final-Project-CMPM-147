using UnityEngine;
using TMPro;

public class StatusWindow : MonoBehaviour
{
    public static StatusWindow Instance;

    public GameObject panel;

    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI SpeedText;
    public TextMeshProUGUI DefenseText;

    private PlayerStats stats;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        stats = FindFirstObjectByType<PlayerStats>();  
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!panel.activeSelf) return;

        HealthText.text = $"Health: {stats.currentHealth}/{stats.maxHealth}";
        DamageText.text = $"Damage Multiplier: x{stats.damageMultiplier}";
        DefenseText.text = $"Defense Multiplier: x{stats.defenseMultiplier}";
        SpeedText.text = $"Speed: {stats.moveSpeed}";
    }

    public void Toggle()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
