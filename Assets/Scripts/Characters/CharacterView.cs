using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterJump characterJump;
    [SerializeField] private HealthController healthController;

    [SerializeField] private string animatorParameterState = "state";
    [SerializeField] private string animatorParameterDeath = "death";
    [SerializeField] private string animatorParameterDoubleJump = "doubleJump";

    private enum MovementState { idle, run, jump, fall }

    private void Reset()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        healthController.onDead += HandleDeath;
        characterJump.onDoubleJump += HandleDoubleJump;
    }

    private void OnDisable()
    {
        healthController.onDead -= HandleDeath;
        characterJump.onDoubleJump -= HandleDoubleJump;
    }

    private void Update()
    {
        MovementState state;

        Vector2 direction = characterMovement.direction;

        float dirX = direction.x;
        bool isMoving = direction != Vector2.zero;

        if (isMoving)
        {
            state = MovementState.run;

            if (dirX < 0f)
            {
                spriteRenderer.flipX = true;
            }

            else
            {
                spriteRenderer.flipX = false;
            }
        }

        else
        {
            state = MovementState.idle;
        }

        if (characterJump.isJumping)
        {
            state = MovementState.jump;
        }

        else if (characterJump.isFalling)
        {
            state = MovementState.fall;
        }

        animator.SetInteger(animatorParameterState, (int)state);
    }

    private void HandleDoubleJump()
    {
        animator.SetTrigger(animatorParameterDoubleJump);
    }

    private void HandleDeath()
    {
        animator.SetTrigger(animatorParameterDeath);
    }
}
