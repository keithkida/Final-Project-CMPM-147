using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 10f;
    private int damage;
    private Vector2 direction;

    public enum ProjectileMode { Safe, Combat }
    public ProjectileMode mode = ProjectileMode.Safe;

    public enum ProjectileOwner
    {
        Player,
        Enemy
    }

    public ProjectileOwner owner;

    void Start()
    {
        // SAFE MODE: disable collider so it can't hit anything
        if (mode == ProjectileMode.Safe)
        {
            Collider2D col = GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;
        }
    }

    public void Init(int dmg, Vector2 dir)
    {
        damage = dmg;
        direction = dir.normalized;

        Debug.Log($"[Projectile] Spawned with damage = {damage}");

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Destroy(gameObject, 3f);
    }

    private bool checkTag(string tag)
    {
        return CompareTag(tag);
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Projectile hit: {other.name}");
        if (mode == ProjectileMode.Safe)
            return;

        if (owner == ProjectileOwner.Player && (other.CompareTag("Enemy") || other.CompareTag("Wall")))
        {
            Debug.Log($"Projectile dealt {damage} damage to {other.name}");
            if (other.TryGetComponent(out BossStats enemy))
                enemy.TakeDamage(damage);
            if (other.TryGetComponent(out WallDurability wall))
            {
                wall.TakeDamage(1);
            }
            Destroy(gameObject);
        }
        else if (owner == ProjectileOwner.Enemy && (other.CompareTag("Player") || other.CompareTag("Wall")))
        {
            Debug.Log($"Projectile dealt {damage} damage to {other.name}");
            if (other.TryGetComponent(out PlayerStats player))
                player.TakeDamage(damage);
            if (other.TryGetComponent(out WallDurability wall))
            {
                wall.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }

}
