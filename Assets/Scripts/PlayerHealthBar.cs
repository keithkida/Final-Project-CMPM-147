using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : MonoBehaviour
{
    public static PlayerHealthBar Instance;

    [SerializeField] private Image fillImage;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reconnect to the new UI Image in the new scene
        fillImage = GameObject.Find("PlayerHealthFill")?.GetComponent<Image>();
    }

    public void UpdateHealth(int current, int max)
    {
        if (fillImage == null) return;

        fillImage.fillAmount = (float)current / max;
    }
}
