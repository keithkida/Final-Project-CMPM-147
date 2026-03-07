using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Melee Weapon")]
public class MeleeWeapon : Weapon
{
    public float range = 1f;

    public override void Use(GameObject user)
    {
        Debug.Log("Melee attack!");
        // You’ll add hitbox logic later
    }
}
