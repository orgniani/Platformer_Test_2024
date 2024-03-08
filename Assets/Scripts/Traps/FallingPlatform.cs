using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 0f;
    [SerializeField] private float accelerationRate = 0.1f;

    [SerializeField] private GameObject fallWaypoint;

    private bool falling = false;

    [SerializeField] private string playerTag = "Player";
    [SerializeField] private TrapBackAndForthMovement movement;
    [SerializeField] private CharacterMovement characterMovement;

    [SerializeField] private HealthController HP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (falling) return;

        if (collision.gameObject.CompareTag(playerTag))
        {
            falling = true;

            movement.enabled = false;
        }
    }

    private void Update()
    {
        if (fallWaypoint == null)
        {
            Debug.LogError($"{name}: Target is null!");
            return;
        }

        if (!falling) return;

        else
        {
            fallSpeed += accelerationRate * Time.deltaTime;
            characterMovement.speed = fallSpeed;

            Vector2 targetPoint = fallWaypoint.transform.position;
            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = targetPoint;

            Vector2 directionToNextPos = nextPosition - currentPosition;
            directionToNextPos.Normalize();

            characterMovement.SetDirection(directionToNextPos);
        }
    }

    private void OnBecameInvisible()
    {
        HP.TakeDamage(1);
    }
}
