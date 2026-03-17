using UnityEngine;

public class SlashEffect : MonoBehaviour
{
    public float slashDuration = 0.15f;
    public float slashFadeRate = 1f;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Destroy(gameObject, slashDuration);
    }

    void Update()
    {
        Color c = sr.color;
        c.a -= slashFadeRate * Time.deltaTime;
        sr.color = c;
    }

    
}