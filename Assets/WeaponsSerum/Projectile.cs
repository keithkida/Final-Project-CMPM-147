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
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // later: damage enemy
        Destroy(gameObject);
    }
}
