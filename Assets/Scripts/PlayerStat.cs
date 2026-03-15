using UnityEngine;
using UnityEngine.SceneManagement;

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
        PlayerHealthBar.Instance.UpdateHealth(currentHealth, maxHealth);

    }

    public int CalculateDamage(int baseDamage)
    {
        return Mathf.RoundToInt(baseDamage * damageMultiplier);
    }

    public void TakeDamage(int amount)
    {
        int finalDamage = Mathf.RoundToInt(amount / defenseMultiplier);
        currentHealth -= finalDamage;
        PlayerHealthBar.Instance.UpdateHealth(currentHealth, maxHealth);
        Debug.Log($"[PlayerStats] Player took {amount} raw damage (final: {finalDamage})");



        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Player died!");
        SceneManager.LoadScene("Lose Screen");
        Destroy(gameObject);
    }


    public void AddHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
        PlayerHealthBar.Instance.UpdateHealth(currentHealth, maxHealth);

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
    
    public void ApplyOrb(Orb orb)
    {
        switch (orb.type)
        {
            case Orb.OrbType.Health:
                AddHealth(orb.intAmount);
                break;

            case Orb.OrbType.Damage:
                AddDamageMultiplier(orb.floatAmount);
                break;

            case Orb.OrbType.Speed:
                AddSpeed(orb.floatAmount);
                break;

            case Orb.OrbType.Defense:
                AddDefenseMultiplier(orb.floatAmount);
                break;
        }

        Debug.Log($"[Orb] Applied {orb.orbName}");
    }

}