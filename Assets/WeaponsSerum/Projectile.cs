using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private int damage;
    private Vector2 direction;

    public enum ProjectileMode { Safe, Combat }
    public ProjectileMode mode = ProjectileMode.Safe;

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
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // SAFE MODE: do nothing at all
        if (mode == ProjectileMode.Safe)
            return;

        // COMBAT MODE: later you can add damage logic here
        Destroy(gameObject);
    }
}
