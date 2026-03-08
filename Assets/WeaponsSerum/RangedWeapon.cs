using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Ranged Weapon")]
public class RangedWeapon : Weapon
{
    public GameObject projectilePrefab;

    [Header("Ammo Settings")]
    public int maxAmmo = 10;
    [HideInInspector] public int currentAmmo;

    private void OnEnable()
    {
        // Reset ammo when the weapon is equipped
        currentAmmo = maxAmmo;
    }

    public override void Use(GameObject user)
    {
        if (currentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }

        Debug.Log("Ranged attack!");

        // 1. Get mouse world position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // 2. Calculate direction
        Vector2 dir = (mousePos - user.transform.position).normalized;

        // 3. Spawn projectile OUTSIDE the player collider
        Vector3 spawnPos = user.transform.position + (Vector3)(dir * 0.8f);
        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        // 4. Convert damage (float) to int
        int dmg = Mathf.RoundToInt(damage);

        // 5. Initialize projectile with damage + direction
        Projectile projectile = proj.GetComponent<Projectile>();
        
        if (projectile != null)
        {
            projectile.Init(dmg, dir);
            currentAmmo--;
        }
        else
        {
            Debug.LogError("Projectile component not found on projectilePrefab!");
        }
    }

}
