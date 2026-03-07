using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Ranged Weapon")]
public class RangedWeapon : Weapon
{
    public GameObject projectilePrefab;

    public override void Use(GameObject user)
    {
        Debug.Log("Ranged attack!");

        // 1. Get direction toward mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mousePos - user.transform.position).normalized;

        // 2. Spawn projectile
        GameObject proj = Instantiate(projectilePrefab, user.transform.position, Quaternion.identity);

        // 3. Convert damage (float) to int
        int dmg = Mathf.RoundToInt(damage);

        // 4. Initialize projectile with damage + direction
        proj.GetComponent<Projectile>().Init(dmg, dir);
    }
}
