using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
    }

    void Update()
    {
        if (playerStats != null)
        {
            healthText.text = "HP: " + playerStats.CurrentHealth;
        }
    }
}
