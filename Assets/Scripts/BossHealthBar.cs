using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public static BossHealthBar Instance;

    [SerializeField] private Image fillImage;
    private BossStats boss;

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

    void Update()
    {
        if (boss == null)
        {
            boss = FindFirstObjectByType<BossStats>();
            return;
        }

        float fill = (float)boss.CurrentHealth / boss.MaxHealth;
        fillImage.fillAmount = fill;
    }
}