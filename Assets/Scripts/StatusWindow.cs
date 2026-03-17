using UnityEngine;
using UnityEngine.SceneManagement;
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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        stats = FindFirstObjectByType<PlayerStats>();
    }

    void Update()
    {
        if (!panel.activeSelf || stats == null) return;

        Refresh();
    }

    public void Refresh()
    {
        if (stats == null) return;

        HealthText.text = $"Health: {stats.currentHealth}/{stats.maxHealth}";
        DamageText.text = $"Damage Multiplier: x{stats.damageMultiplier}";
        DefenseText.text = $"Defense Multiplier: x{stats.defenseMultiplier}";
        SpeedText.text = $"Speed: {stats.moveSpeed}";
    }

}
