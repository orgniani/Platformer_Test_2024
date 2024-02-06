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

    public VoidDelegateType onJump;

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

        if (shouldJump && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            shouldJump = false;

            if (onJump != null)
                onJump();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}