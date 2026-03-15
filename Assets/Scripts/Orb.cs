using UnityEngine;

public class Orb : MonoBehaviour
{
    public OrbType type;
    public int intAmount;
    public float floatAmount;

    public string orbName;
    [TextArea] public string description;

    public enum OrbType {
        Health,
        Damage,
        Speed,
        Defense,
    }
}
