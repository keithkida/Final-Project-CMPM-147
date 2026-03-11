using UnityEngine;

public class InteractPanel : MonoBehaviour
{
    public GameObject PressEPanel;
    public GameObject InteractPanelUI;
    public bool isPlayerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger!");
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }    

    private void Update()
    {
        if (PressEPanel != null)
        {
            PressEPanel.SetActive(isPlayerInRange);
            InteractPanelUI.SetActive(isPlayerInRange);
        }
        else
        {
            Debug.LogWarning("PressEPanel is not assigned in the Inspector!");
        }
    }
}
