using UnityEngine;

public class PickaxePickup : MonoBehaviour
{
    public int uses = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            stats.pickUse = uses;

            PickaxeUI.Instance.Show(stats.pickUse); 

            Destroy(gameObject);
        }
    }
}
