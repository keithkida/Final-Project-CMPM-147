using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float Cooldown;

    public abstract void Use(GameObject user);
}
