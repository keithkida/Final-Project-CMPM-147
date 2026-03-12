using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public int basemeleeDamage = 10;
    public int baseRangedDamage = 5;

    public float meleeMultiplier = 1f;
    public float rangedMultiplier = 1f;

    public Weapon meleeWeapon;
    public Weapon rangedWeapon;
    public Serum serumBuff;

    public void ResetInventory()
    {
        meleeWeapon = null;
        rangedWeapon = null;
        serumBuff = null;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if (meleeWeapon == null)
            {
                Debug.Log("No melee weapon aquired!");
                return;
            }
            int finalDamage = (int)((meleeWeapon.damage + basemeleeDamage) * meleeMultiplier);
            meleeWeapon?.Use(gameObject, finalDamage);
            Debug.Log($"Weapon:{meleeWeapon.name} Melee attack damage: {finalDamage}");
        }

        if(Input.GetMouseButtonDown(1)){
            if (rangedWeapon == null)
            {
                Debug.Log("No ranged weapon aquired!");
                return;
            }
            int finalDamage = (int)((rangedWeapon.damage + baseRangedDamage) * rangedMultiplier);
            rangedWeapon?.Use(gameObject, finalDamage);
            Debug.Log($"Weapon:{rangedWeapon.name} Ranged attack damage: {finalDamage}");
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            if (serumBuff == null)
            {
                Debug.Log("No serum buff acquired!");
                return;
            }
            serumBuff.Use(gameObject);
            Debug.Log($"Serum: {serumBuff.name} buff applied!");
        }
    }
}
