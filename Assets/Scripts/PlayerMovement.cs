using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector2 FacingDirection { get; private set; } = Vector2.down;
    private PlayerStats stats;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        if (movement.sqrMagnitude > 0.01f)
        {
            FacingDirection = movement;
        }
    }

    public Vector2 GetFacingDirection()
    {
        return FacingDirection;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * stats.moveSpeed * Time.fixedDeltaTime);
    }
}
