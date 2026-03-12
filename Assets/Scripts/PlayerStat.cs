using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Base Stats")]
    public int maxHealth = 100;
    public float moveSpeed = 5f;
    public float damageMultiplier = 1f; 
    public float defenseMultiplier = 1f; 

    private int currentHealth;

    public int CurrentHealth => currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ResetStats()
    {
        currentHealth = maxHealth;
    }

    public int CalculateDamage(int baseDamage)
    {
        return Mathf.RoundToInt(baseDamage * damageMultiplier);
    }

    public void TakeDamage(int amount)
    {
        int finalDamage = Mathf.RoundToInt(amount / defenseMultiplier);
        currentHealth -= finalDamage;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }

    // Orb upgrades
    public void AddHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
    }

    public void AddDamageMultiplier(float amount)
    {
        damageMultiplier += amount;
    }

    public void AddDefenseMultiplier(float amount)
    {
        defenseMultiplier += amount;
    }

    public void AddSpeed(float amount)
    {
        moveSpeed += amount;
    }
}