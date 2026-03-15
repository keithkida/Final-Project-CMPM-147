using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] private TMP_Text meleeLabel;
    [SerializeField] private TMP_Text longRangeLabel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ResetUI()
    {
        meleeLabel.text = "Melee";
        meleeLabel.color = Color.white;
        longRangeLabel.text = "Ranged";
        longRangeLabel.color = Color.white;
    }

    private Color GetRarityColor(string rarity)
    {
        switch (rarity)
        {
            case "Common":
                return Color.white;
            case "Uncommon":
                return Color.green;
            case "Rare":
                return Color.blue;
            case "Epic":
                return new Color(0.6f, 0f, 0.8f); // Purple
            case "Legendary":
                return new Color(1f, 0.84f, 0f); // Gold
            default:
                return Color.white;
        }
    }

    public void SetMeleeItem(LootChest.gameItem item)
    {
        meleeLabel.text = item.name;
        Debug.Log("Updating melee label to: " + item.name);
        meleeLabel.color = GetRarityColor(item.rarity);
    }

    public void SetLongRangeItem(LootChest.gameItem item)
    {
        longRangeLabel.text = item.name;
        Debug.Log("Updating ranged label to: " + item.name);
        longRangeLabel.color = GetRarityColor(item.rarity);
    }



    
}
