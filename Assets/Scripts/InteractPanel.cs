using UnityEngine;

public class InteractPanel : MonoBehaviour
{
    public GameObject PressEPanel;
    public GameObject InteractPanelUI;
    public bool isPlayerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && CompareTag("Interactable"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && CompareTag("Interactable"))
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        PressEPanel.SetActive(isPlayerInRange);
        InteractPanelUI.SetActive(isPlayerInRange);
    }

    public void Hide()
    {
        isPlayerInRange = false;
        PressEPanel.SetActive(false);
        InteractPanelUI.SetActive(false);
    }
}
