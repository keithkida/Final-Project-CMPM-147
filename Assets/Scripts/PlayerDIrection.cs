using UnityEngine;

public class PlayerDIrection : MonoBehaviour
{
    public Sprite UpSprite;
    public Sprite DownSprite;
    public Sprite LeftSprite;
    public Sprite RightSprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x > 0) {
            spriteRenderer.sprite = RightSprite;
        } else if (x < 0) {
            spriteRenderer.sprite = LeftSprite;
        } else if (y > 0) {
            spriteRenderer.sprite = UpSprite;
        } else if (y < 0) {
            spriteRenderer.sprite = DownSprite;
        }
    }
}
