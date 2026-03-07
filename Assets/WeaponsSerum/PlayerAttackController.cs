using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public Weapon meleeWeapon;
    public Weapon rangedWeapon;
    public Serum serumBuff;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            meleeWeapon?.Use(gameObject);
        }

        if(Input.GetMouseButtonDown(1)){
            rangedWeapon?.Use(gameObject);
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            serumBuff?.Use(gameObject);
        }
    }
}
