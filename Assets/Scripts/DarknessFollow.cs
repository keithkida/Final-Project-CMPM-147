using UnityEngine;
using UnityEngine.SceneManagement;

public class DarknessFollow : MonoBehaviour
{
    public Transform player;
    public Material mat;
    public float radius = 0.15f;

    void Start()
    {
        mat.SetFloat("_Radius", radius);
    }

    void Update()
    {
        // Disable in boss room
        if (SceneManager.GetActiveScene().name == "Boss Room")
        {
            gameObject.SetActive(false);
            return;
        }

        // Normal behavior in gameplay
        Vector2 vp = Camera.main.WorldToViewportPoint(player.position);
        mat.SetVector("_Center", vp);
    }

    void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "Boss Room")
            gameObject.SetActive(false);
    }

}
