using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : MonoBehaviour
{
    [Header("Boss Stats")]
    public int maxHealth = 100;
    private int currentHealth;

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
        SceneManager.LoadScene("Win Screen");
        Destroy(gameObject);
    }
}
