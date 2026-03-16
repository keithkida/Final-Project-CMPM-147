using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : MonoBehaviour
{
    [Header("Boss Stats")]
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 100;

    [Header("Scaling Per Defeat")]
    public float healthMultiplierPerDefeat = 1.5f;
    public float damageMultiplierPerDefeat = 1.5f;
    public float defenseMultiplier = 1f;
    public float defenseMultiplierPerDefeat = 0.1f;

    [Header("Boss Damage")]
    public int damage = 10;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    void Start()
    {
        int defeats = BossDefeatTracker.timesDefeated;


        float healthMultiplier = 1f + (defeats * healthMultiplierPerDefeat);
        float damageMultiplier = 1f + (defeats * damageMultiplierPerDefeat);

        maxHealth = Mathf.RoundToInt(maxHealth * healthMultiplier);
        currentHealth = maxHealth;

        defenseMultiplier = 1f + (defeats * defenseMultiplierPerDefeat);
        Debug.Log($"[BossStats] Boss defense multiplier = {defenseMultiplier}");


        damage = Mathf.RoundToInt(damage * damageMultiplier);
        Debug.Log($"[BossStats] Boss scaled damage = {damage} after {defeats} defeats");
    }

    public void TakeDamage(int amount)
    {
        int finalDamage = Mathf.RoundToInt(amount / defenseMultiplier);
        currentHealth -= finalDamage;

        Debug.Log($"[BossStats] Took {finalDamage} damage (raw: {amount}, defenseMult: {defenseMultiplier})");

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Boss defeated!");
        // TODO: Load win screen or trigger cutscene
        SceneManager.LoadScene("GamePlay");
        Destroy(gameObject);
        BossDefeatTracker.timesDefeated++;
    }
}
