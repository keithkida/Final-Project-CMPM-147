using UnityEngine;

public class PickaxePickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player == null) return;

        player.hasPickaxe = true;
        Debug.Log("[Pickaxe] Player obtained the pickaxe!");

        Destroy(gameObject);
    }
}
