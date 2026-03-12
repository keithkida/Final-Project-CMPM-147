using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public static HealthUI Instance;
    [SerializeField] private TMP_Text healthText;
    private PlayerStats playerStats;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
    }

    public void ResetUI()
    {
        healthText.text = "HP: 100";
    }

    void Update()
    {
        if (playerStats != null)
        {
            healthText.text = "HP: " + playerStats.CurrentHealth;
        }
    }
}
