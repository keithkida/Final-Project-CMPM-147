using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private PlayerStats stats;

    public int basemeleeDamage = 10;
    public int baseRangedDamage = 5;

    public Weapon meleeWeapon;
    public Weapon rangedWeapon;

    private Weapon newWeapon;
    private bool choosingWeapon;

    public GameObject slashPrefab;

    private BreakableStone stoneInRange;

    private AudioSource audioSource;


    void Start()
    {
        stats = GetComponent<PlayerStats>();
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
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
                NoWeaponUI.Instance.ShowMelee();
                Debug.Log("No melee weapon acquired!");
                return;
            }

            int finalDamage = Mathf.RoundToInt((meleeWeapon.damage + basemeleeDamage) * stats.damageMultiplier);
            meleeWeapon.Use(gameObject, finalDamage);
            PlaySlashEffect();
            audioSource.PlayOneShot(((MeleeWeapon)meleeWeapon).swingAudio);
            Debug.Log($"Weapon:{meleeWeapon.name} Melee attack damage: {finalDamage}");

        }

        // Ranged attack
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space))
        {
            if (rangedWeapon == null)
            {
                NoWeaponUI.Instance.ShowRanged();
                Debug.Log("No ranged weapon acquired!");
                return;
            }

            int finalDamage = Mathf.RoundToInt((rangedWeapon.damage + baseRangedDamage) * stats.damageMultiplier);
            rangedWeapon.Use(gameObject, finalDamage);
            audioSource.PlayOneShot(((RangedWeapon)rangedWeapon).shootAudio);
            Debug.Log($"Weapon:{rangedWeapon.name} Ranged attack damage: {finalDamage}");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TryUsePickaxe();
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
        else if (w is RangedWeapon ranged)
        {
            rangedWeapon = w;
            ui.SetLongRangeItemFromWeapon(w);

            AmmoUI.Instance.Show();
            AmmoUI.Instance.UpdateAmmo(ranged.currentAmmo, ranged.maxAmmo);
        }

    }

    private void RefillAmmoIfRanged(Weapon w)
    {
        if (w is RangedWeapon ranged)
        {
            ranged.currentAmmo = ranged.maxAmmo;
            AmmoUI.Instance.Show();
            AmmoUI.Instance.UpdateAmmo(ranged.currentAmmo, ranged.maxAmmo);
        }
    }

    void PlaySlashEffect()
    {
        Vector2 direction = playerMovement.GetFacingDirection();
        Vector3 spawnPos = transform.position + (Vector3)(direction * 0.7f);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Instantiate(
            slashPrefab,
            spawnPos,
            Quaternion.Euler(0, 0, angle)
        );
    }

    void TryUsePickaxe()
    {
        if (stats.pickUse <= 0)
        {
            NoPickaxeUI.Instance.Show();
            Debug.Log("No pickaxe uses left!");
            return;
        }

        if (stoneInRange != null)
        {
            stats.pickUse--;
            stoneInRange.Break();

            PickaxeUI.Instance.UpdateUses(stats.pickUse); 

            Debug.Log("Pickaxe used! Remaining uses: " + stats.pickUse);
        }
        else
        {
            Debug.Log("No breakable stone touching you.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))
        {
            stoneInRange = other.GetComponent<BreakableStone>();
            BreakPromptUI.Instance.Show();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))
        {
            if (stoneInRange != null && stoneInRange.gameObject == other.gameObject)
                stoneInRange = null;
                BreakPromptUI.Instance.Hide();
        }
    }
 

}
