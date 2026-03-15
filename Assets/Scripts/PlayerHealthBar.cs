using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public static PlayerHealthBar Instance;

    [SerializeField] private Image fillImage;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateHealth(int current, int max)
    {
        float fill = (float)current / max;
        fillImage.fillAmount = fill;
    }
}
