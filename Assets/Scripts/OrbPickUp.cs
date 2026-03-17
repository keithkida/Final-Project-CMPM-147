using UnityEngine;

public class OrbPickUp : MonoBehaviour
{
    private Orb orb;

    void Awake()
    {
        orb = GetComponent<Orb>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        OrbPopupUI.Instance.Show(orb);

        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player == null) return;

        player.ApplyOrb(orb);
        Destroy(gameObject);
    }
}
