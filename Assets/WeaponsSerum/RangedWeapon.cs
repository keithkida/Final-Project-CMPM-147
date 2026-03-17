using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Ranged Weapon")]
public class RangedWeapon : Weapon
{
    public GameObject projectilePrefab;
    public AudioClip shootAudio;

    [Header("Ammo Settings")]
    public int maxAmmo = 10;
    [HideInInspector] public int currentAmmo;
    // private float projectileOffset = 1f;


    private void OnEnable()
    {
        // Reset ammo when the weapon is equipped
        currentAmmo = maxAmmo;
    }

    public override void Use(GameObject user, int finalDamage)
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

        Transform firePoint = user.transform.Find("FirePoint");
        Vector3 spawnPos = firePoint.position;


        // 2. Calculate direction
        Vector2 dir = (mousePos - user.transform.position).normalized;


        Debug.DrawLine(user.transform.position, mousePos, Color.red, 1f);
        Debug.Log($"Mouse: {mousePos}, Player: {user.transform.position}, Dir: {dir}");
    

        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        // 5. Initialize projectile with damage + direction
        Projectile projectile = proj.GetComponent<Projectile>();
        
        if (projectile != null)
        {
            projectile.owner = Projectile.ProjectileOwner.Player;
            projectile.Init(finalDamage, dir);
            currentAmmo--;
            AmmoUI ammoUI = Object.FindFirstObjectByType<AmmoUI>();
            if (ammoUI != null)
            {
                Debug.Log($"[RangedWeapon] Updating ammo to {currentAmmo}/{maxAmmo}");
                AmmoUI.Instance.UpdateAmmo(currentAmmo, maxAmmo);
            }
        }
        else
        {
            Debug.LogError("Projectile component not found on projectilePrefab!");
        }
    }

}
