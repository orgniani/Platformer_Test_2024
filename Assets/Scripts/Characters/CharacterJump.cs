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

    public VoidDelegateType onJump;

    private bool isSliding;
    [SerializeField] private float wallSlidingSpeed;

    [SerializeField] private float wallJumpDuration;
    [SerializeField] private float wallJumpForce;
    private bool wallJumping;

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

        if (shouldJump)
        {
            JumpingAction();
        }

        if(IsOnWall() && !IsGrounded() && !shouldJump)
        {
            isSliding = true;
        }

        else
        {
            isSliding = false;
        }

        if(isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if(wallJumping)
        {
            rb.AddForce(Vector2.up * wallJumpForce, ForceMode2D.Impulse);
        }
    }

    private void JumpingAction()
    {
        if(IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        else if(isSliding)
        {
            wallJumping = true;
            Invoke("StopWallJump", wallJumpDuration);

        }

        shouldJump = false;

        if (onJump != null)
            onJump();
    }

    private void StopWallJump()
    {
        wallJumping = false;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, ground);
        return raycastHit.collider != null;
    }

    private bool IsOnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, new Vector2(transform.localScale.x, 0), .1f, wall);
        return raycastHit.collider != null;
    }

}