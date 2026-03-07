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
                stats.ApplyDamageBuff(strength, duration);
                break;

            case SerumType.Speed:
                stats.ApplySpeedBuff(strength, duration);
                break;

            case SerumType.Defense:
                stats.ApplyDefenseBuff(strength, duration);
                break;

            case SerumType.Heal:
                stats.TakeDamage(-healAmount); // negative damage = heal
                break;
        }
    }
}

