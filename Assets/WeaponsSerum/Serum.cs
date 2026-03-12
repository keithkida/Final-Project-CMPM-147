using UnityEngine;

public enum SerumType
{
    Damage,
    Speed,
    Defense,
    Heal
}

[CreateAssetMenu(menuName = "Items/Serum")]
public class Serum : ScriptableObject
{
    public string serumName;
    public SerumType serumType;

    [Header("Buff Settings")]
    public float strength = 1.2f;   // multiplier for damage/speed/defense
    public float duration = 5f;     // how long the buff lasts

    [Header("Healing")]
    public int healAmount = 0;      // only used for Heal serums

    public void Use(GameObject user)
    {
        PlayerStats stats = user.GetComponent<PlayerStats>();

        switch (serumType)
        {
            case SerumType.Damage:
                stats.AddDamageMultiplier(strength);
                break;

            case SerumType.Speed:
                stats.AddSpeed(strength);
                break;

            case SerumType.Defense:
                stats.AddDefenseMultiplier(strength);
                break;

            case SerumType.Heal:
                stats.AddHealth(-healAmount); // negative damage = heal
                break;
        }

    }
}

