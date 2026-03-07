using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private int damage;
    private Vector2 direction;

    public void Init(int dmg, Vector2 dir)
    {
        damage = dmg;
        direction = dir.normalized;
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // later: damage enemy
        Destroy(gameObject);
    }
}
