using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector2 moveInput;

    private bool isFacingRight = true;
    private bool jumpPressed = false;


    public float velocity;
    public float jumpForce = 12f;
    public InputAction MoveAction;
    public InputAction JumpAction;


    private void Awake()
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
        MoveAction.Enable();
        JumpAction.Enable();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * velocity, rb.linearVelocity.y);

        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
        }
    }

    void Update()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        jumpPressed = JumpAction.WasPressedThisFrame();
        Vector2 position = (Vector2)transform.position + moveInput * velocity * Time.deltaTime;
        transform.position = position;

        Flip();

        if (moveInput != Vector2.zero)
        {
            Debug.Log("O jogador est� andando");
            animator.SetBool("isWalkingTrigger", true);
        }
        else {
            Debug.Log("O jogador est� parado");
            animator.SetBool("isWalkingTrigger", false);
        }


    }

    void Flip() {
        if (moveInput.x > 0 && !isFacingRight || moveInput.x < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;

            spriteRenderer.flipX = !isFacingRight;
        }
    }

}
