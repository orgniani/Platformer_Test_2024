using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;

    private bool shouldJump = false;

    public bool isJumping = false;
    public bool isFalling = false;

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask wall;

    [SerializeField] private int maxJumps = 2;
    private int jumpCount = 0;

    public VoidDelegateType onJump; // This is for the audio only
    public VoidDelegateType onDoubleJump; // This is for animation only

    [SerializeField] private ParticleSystem runningDust;
    [SerializeField] private CharacterMovement characterMovement;

    private void OnEnable()
    {
        if (!rb)
        {
            Debug.Log(message: $"{name}: rigidbody2D is null"
                                + $"\nDisabling to avoid nullReference");
            enabled = false;
        }

        if (!boxCollider)
        {
            Debug.Log(message: $"{name}: boxCollider is null"
                                + $"\nDisabling to avoid nullReference");
            enabled = false;
        }
    }
    public void Jump()
    {
        shouldJump = true;
    }

    private void FixedUpdate()
    {
        isJumping = rb.velocity.y > .1f;
        isFalling = rb.velocity.y < -.1f;

        Vector2 direction = characterMovement.direction;
        bool isMoving = direction != Vector2.zero;

        if (IsGrounded())
        {
            jumpCount = 0;

            if(isMoving)
            {
                runningDust.Play();
            }
        }

        if (shouldJump)
        {
            JumpingAction();
        }
    }

    private void JumpingAction()
    {
        if(IsGrounded() || jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;

            if (onJump != null)
                onJump();

            if (jumpCount == 2)
            {
                if (onDoubleJump != null)
                    onDoubleJump();
            }
        }

        shouldJump = false;

    }

    public void JumpAfterKill()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, ground);
        return raycastHit.collider != null;
    }

}