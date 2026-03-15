using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public int durability = 1;

    public void TakeDamage(int amount)
    {
        durability -= amount;

        if (durability <= 0)
            Destroy(gameObject);
    }
}
