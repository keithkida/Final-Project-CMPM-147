using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private PlayerStats stats;

    public int basemeleeDamage = 10;
    public int baseRangedDamage = 5;

    public Weapon meleeWeapon;
    public Weapon rangedWeapon;

    private Weapon newWeapon;
    private bool choosingWeapon;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    public void ResetInventory()
    {
        meleeWeapon = null;
        rangedWeapon = null;
    }


    void Update()
    {
        // Melee attack
        if (Input.GetMouseButtonDown(0))
        {
            if (meleeWeapon == null)
            {
                Debug.Log("No melee weapon acquired!");
                return;
            }

            int finalDamage = Mathf.RoundToInt((meleeWeapon.damage + basemeleeDamage) * stats.damageMultiplier);
            meleeWeapon.Use(gameObject, finalDamage);
            Debug.Log($"Weapon:{meleeWeapon.name} Melee attack damage: {finalDamage}");
        }

        // Ranged attack
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space))
        {
            if (rangedWeapon == null)
            {
                Debug.Log("No ranged weapon acquired!");
                return;
            }

            int finalDamage = Mathf.RoundToInt((rangedWeapon.damage + baseRangedDamage) * stats.damageMultiplier);
            rangedWeapon.Use(gameObject, finalDamage);
            Debug.Log($"Weapon:{rangedWeapon.name} Ranged attack damage: {finalDamage}");
        }

        // Handle Keep / Replace choice
        if (choosingWeapon)
        {
            if (Input.GetKeyDown(KeyCode.C))
                ReplaceWeapon();

            if (Input.GetKeyDown(KeyCode.X))
                KeepWeapon();
        }
    }

    public void TryPickupWeapon(Weapon weaponFromChest)
    {
        bool isNewMelee = weaponFromChest is MeleeWeapon;
        bool isNewRanged = weaponFromChest is RangedWeapon;

        // CASE 1: Player has NO weapon of this type → auto equip
        if (isNewMelee && meleeWeapon == null)
        {
            EquipWeapon(weaponFromChest);
            return;
        }

        if (isNewRanged && rangedWeapon == null)
        {
            EquipWeapon(weaponFromChest);
            RefillAmmoIfRanged(weaponFromChest);
            return;
        }

        // CASE 2: Player already has a weapon of this type → show choice
        newWeapon = weaponFromChest;
        choosingWeapon = true;

        string currentName = isNewMelee ? meleeWeapon.weaponName : rangedWeapon.weaponName;
        string newName = weaponFromChest.weaponName;

        ReplaceUI.Instance.Show(
            $"Would you like to keep <color=yellow>{currentName}</color> or replace it with <color=green>{newName}</color>?\n\n" +
            "Press <color=red>X</color> to Keep\n" +
            "Press <color=green>C</color> to Replace"
        );
    }


        

    private void ReplaceWeapon()
    {
        if (newWeapon is MeleeWeapon)
            meleeWeapon = null;

        if (newWeapon is RangedWeapon)
            rangedWeapon = null;

        EquipWeapon(newWeapon);
        RefillAmmoIfRanged(newWeapon);

        choosingWeapon = false;
        newWeapon = null;
        ReplaceUI.Instance.Hide();
    }

    

    private void KeepWeapon()
    {
        // Just discard the new weapon reference
        newWeapon = null;

        // Refill ammo on current weapon
        if (rangedWeapon != null)
            RefillAmmoIfRanged(rangedWeapon);

        choosingWeapon = false;
        ReplaceUI.Instance.Hide();
    }

    private void EquipWeapon(Weapon w)
    {
        InventoryUI ui = InventoryUI.Instance;

        if (w is MeleeWeapon)
        {
            meleeWeapon = w;
            ui.SetMeleeItemFromWeapon(w);
        }
        else if (w is RangedWeapon)
        {
            rangedWeapon = w;
            ui.SetLongRangeItemFromWeapon(w);
            }
    }

    private void RefillAmmoIfRanged(Weapon w)
    {
        if (w is RangedWeapon ranged)
        {
            ranged.currentAmmo = ranged.maxAmmo;
            AmmoUI.Instance.UpdateAmmo(ranged.currentAmmo, ranged.maxAmmo);
        }
    }
}
