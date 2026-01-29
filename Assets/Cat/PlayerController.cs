using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public float velocity = 4f;
    public float jumpForce = 6f;

    public InputAction MoveAction;
    public InputAction JumpAction;

    private Vector2 moveInput;
    private bool canJump = true;
    private bool isFacingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        MoveAction.Enable();
        JumpAction.Enable();
    }

    void OnDisable()
    {
        MoveAction.Disable();
        JumpAction.Disable();
    }

    void Update()
    {
        // MOVIMENTO
        moveInput = MoveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * velocity, rb.linearVelocity.y);

        animator.SetBool("isWalkingTrigger", moveInput.x != 0);
        Flip();

        // --- PULO (IGUAL AO SCRIPT BASE) ---
        canJump = Mathf.Abs(rb.linearVelocity.y) <= 0.001f;

        if (canJump && JumpAction.IsPressed())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        if (moveInput.x > 0 && !isFacingRight || moveInput.x < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            spriteRenderer.flipX = !isFacingRight;
        }
    }
}
