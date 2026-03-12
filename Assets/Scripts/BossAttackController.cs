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
            ShootProjectile();
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

}
