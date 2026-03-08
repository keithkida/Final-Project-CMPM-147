using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Loot/Loot Database")]
public class LootDatabase : ScriptableObject
{
    public List<MeleeWeapon> meleeWeapons;
    public List<RangedWeapon> rangedWeapons;
    public List<Serum> serums;

    public MeleeWeapon GetMelee(string name)
        => meleeWeapons.Find(w => w.weaponName == name);

    public RangedWeapon GetRanged(string name)
        => rangedWeapons.Find(w => w.weaponName == name);

    public Serum GetSerum(string name)
        => serums.Find(s => s.serumName == name);
}
