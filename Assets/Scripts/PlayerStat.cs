using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Base Stats")]
    public int maxHealth = 100;
    public float moveSpeed = 5f;
    public float damageMultiplier = 1f;
    public float defenseMultiplier = 1f;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Called by melee or ranged weapons
    public int CalculateDamage(int baseDamage)
    {
        return Mathf.RoundToInt(baseDamage * damageMultiplier);
    }

    // Called when player takes damage
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
        // TODO: respawn or game over
    }

    // Called by serums
    public void ApplyDamageBuff(float multiplier, float duration)
    {
        StartCoroutine(DamageBuffRoutine(multiplier, duration));
    }

    public void ApplySpeedBuff(float multiplier, float duration)
    {
        StartCoroutine(SpeedBuffRoutine(multiplier, duration));
    }

    public void ApplyDefenseBuff(float multiplier, float duration)
    {
        StartCoroutine(DefenseBuffRoutine(multiplier, duration));
    }

    private System.Collections.IEnumerator DamageBuffRoutine(float mult, float duration)
    {
        damageMultiplier *= mult;
        yield return new WaitForSeconds(duration);
        damageMultiplier /= mult;
    }

    private System.Collections.IEnumerator SpeedBuffRoutine(float mult, float duration)
    {
        moveSpeed *= mult;
        yield return new WaitForSeconds(duration);
        moveSpeed /= mult;
    }

    private System.Collections.IEnumerator DefenseBuffRoutine(float mult, float duration)
    {
        defenseMultiplier *= mult;
        yield return new WaitForSeconds(duration);
        defenseMultiplier /= mult;
    }
}
