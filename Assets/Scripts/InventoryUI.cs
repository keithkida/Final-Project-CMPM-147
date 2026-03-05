using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;    
    public Transform slotParent;     
    public GameObject slotPrefab;     

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.SetActive(!gameObject.activeSelf);
            RefreshUI();
        }
    }

    public void RefreshUI()
    {
        // Clear old slots
        foreach (Transform child in slotParent)
            Destroy(child.gameObject);

        // Create new slots
        foreach (var item in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);

            // Set label text
            slot.transform.Find("Label").GetComponent<TextMeshProUGUI>().text =
                item.name;


            Image iconImage = slot.transform.Find("Icon").GetComponent<Image>();
            if (item.icon != null)
                iconImage.sprite = item.icon;
        }
    }
}
