    using UnityEngine;

public class WallDurability : MonoBehaviour
{
    public int maxDurability = 10;
    private int currentDurability;

    void Start()
    {
        currentDurability = maxDurability;
    }

    public void TakeDamage(int amount)
    {
        currentDurability -= amount;
        Debug.Log($"Wall took {amount} damage, durability now {currentDurability}/{maxDurability}");

        if (currentDurability <= 0){
            Destroy(gameObject);
            Debug.Log("Wall destroyed!");
        }
    }
}
