using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : MonoBehaviour
{
    [Header("Boss Stats")]
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 100;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

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
