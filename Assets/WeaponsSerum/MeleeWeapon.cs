using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Melee Weapon")]
public class MeleeWeapon : Weapon
{
    public float range = 1f;
    public float offset = 11f;
    public AudioClip swingAudio;
    public enum MeleeOwner
    {
        Player,
        Enemy
    }

    public MeleeOwner owner = MeleeOwner.Player;

    public override void Use(GameObject user, int finalDamage)
    {
        Debug.Log("Melee attack!");
        Vector2 direction = user.GetComponent<PlayerMovement>().GetFacingDirection();
        Vector2 origin = (Vector2)user.transform.position + direction * offset;

        Debug.DrawRay(origin, direction * range, Color.red, 1f);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, range);

        if (hit.collider != null && hit.collider.CompareTag("Enemy") && owner == MeleeOwner.Player)
        {
            Debug.Log($"Hit {hit.collider.name} with melee weapon for {finalDamage} damage!");
            if (hit.collider.TryGetComponent(out BossStats enemy))
                enemy.TakeDamage(finalDamage);
        }
        // You'll add hitbox logic later
    }
}
