using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootInterval = 5f;
    public int projectileDamage = 10;
    public float projectileoffset= 1f;

    private Transform player;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(player == null){
            return;
        }

        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            int attackType = Random.Range(0, 3);
            switch (attackType)
            {
                case 0:
                    ShootProjectile();
                    break;
                case 1:
                    ShootStraightChain();
                    break;
                case 2:
                    ShotSpread();
                    break;
            }
            timer = 0f;
        }
    }

    void ShootProjectile()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        Vector3 spawnPos = transform.position + (Vector3)(direction * projectileoffset);
        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        Projectile projectile = proj.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.Init(projectileDamage, direction);
            projectile.owner = Projectile.ProjectileOwner.Enemy;
            projectile.mode = Projectile.ProjectileMode.Combat;
            projectile.Init(projectileDamage, direction);
        }

        Debug.Log("Boss shoots a projectile!");
    }

    void ShootStraightChain()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        // Distance between bullets in the chain
        float spacing = 1.2f;

        for (int i = 0; i < 5; i++)
        {
            // Each bullet is placed further BACK along the direction
            Vector3 spawnPos =
                transform.position +
                (Vector3)(direction * projectileoffset) -
                (Vector3)(direction * spacing * i);

            SpawnProjectile(direction, spawnPos);
        }

        Debug.Log("Boss fired a straight chain!");
    }

    void ShotSpread()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        float[] angles = { -20f, -10f, 0f, 10f, 20f };

        foreach (float angle in angles)
        {
            Vector2 shotDir = Quaternion.Euler(0, 0, angle) * direction;
            Vector3 spawnPos = transform.position + (Vector3)(shotDir * projectileoffset);

            SpawnProjectile(shotDir, spawnPos);
        }
        Debug.Log("Boss fired a spread shot!");
    }

    void SpawnProjectile(Vector2 direction, Vector3 spawnPos)
    {
        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        Projectile projectile = proj.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Init(projectileDamage, direction);
            projectile.owner = Projectile.ProjectileOwner.Enemy;
            projectile.mode = Projectile.ProjectileMode.Combat;
        }
    }

}
