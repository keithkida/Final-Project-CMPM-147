using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private PlayerStats stats;
    public int basemeleeDamage = 10;
    public int baseRangedDamage = 5;

    public Weapon meleeWeapon;
    public Weapon rangedWeapon;
    public Serum serumBuff;

    public void ResetInventory()
    {
        meleeWeapon = null;
        rangedWeapon = null;
        serumBuff = null;
    }

    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if (meleeWeapon == null)
            {
                Debug.Log("No melee weapon aquired!");
                return;
            }
            int finalDamage = Mathf.RoundToInt((meleeWeapon.damage + basemeleeDamage) * stats.damageMultiplier);
            meleeWeapon?.Use(gameObject, finalDamage);
            Debug.Log($"Weapon:{meleeWeapon.name} Melee attack damage: {finalDamage}");
        }

        if(Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space)){
            if (rangedWeapon == null)
            {
                Debug.Log("No ranged weapon aquired!");
                return;
            }
            int finalDamage = (int)((rangedWeapon.damage + baseRangedDamage) * stats.damageMultiplier);;
            rangedWeapon?.Use(gameObject, finalDamage);
            Debug.Log($"Weapon:{rangedWeapon.name} Ranged attack damage: {finalDamage}");
        }

    }
}
