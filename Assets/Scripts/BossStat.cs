using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : MonoBehaviour
{
    [Header("Boss Stats")]
    [SerializeField] private int baseMaxHealth = 100;
    [SerializeField] private int baseDamage = 10;
    [SerializeField] private float baseDefenseMultiplier = 1f;
    [SerializeField] private float baseShootInterval = 5f;

    [Header("Runtime Stats")]
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    public float defenseMultiplier;
    public float scaledShootInterval;
    public int damage;

    [Header("Scaling Per Defeat")]
    public float healthMultiplierPerDefeat = 1.5f;
    public float damageMultiplierPerDefeat = 1.5f;
    public float defenseMultiplierPerDefeat = 0.1f;
    public float shootIntervalMultiplierPerDefeat = 0.9f;
    public float minShootInterval = 1f;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;          


    void Start()
    {
        int defeats = BossDefeatTracker.timesDefeated;

        maxHealth = baseMaxHealth;
        damage = baseDamage;
        defenseMultiplier = baseDefenseMultiplier;
        scaledShootInterval = baseShootInterval;

        float healthMultiplier = 1f + (defeats * healthMultiplierPerDefeat);
        float damageMultiplier = 1f + (defeats * damageMultiplierPerDefeat);
        float intervalMultiplier = Mathf.Pow(shootIntervalMultiplierPerDefeat, defeats);
        
        maxHealth = Mathf.RoundToInt(maxHealth * healthMultiplier);
        currentHealth = maxHealth;

        damage = Mathf.RoundToInt(damage * damageMultiplier);
        Debug.Log($"[BossStats] Boss scaled damage = {damage} after {defeats} defeats");

        defenseMultiplier = 1f + (defeats * defenseMultiplierPerDefeat);
        Debug.Log($"[BossStats] Boss defense multiplier = {defenseMultiplier}");

        scaledShootInterval = Mathf.Max(minShootInterval, baseShootInterval * intervalMultiplier);
        Debug.Log($"[BossStats] Boss shoot interval scaled to {scaledShootInterval} after {defeats} defeats");

        Debug.Log($"[BossStats] Boss initialized. Defeats={defeats}, HP={maxHealth}, DMG={damage}, DEF={defenseMultiplier}, ShootInterval={scaledShootInterval}");
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
