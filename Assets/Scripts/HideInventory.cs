using UnityEngine;

public class HideInventory : MonoBehaviour
{
    public GameObject inventoryUI;

    void Start()
    {
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}