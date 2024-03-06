using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float speed = 4f;

    public Vector2 direction;
    public Vector2 lastDirection;

    public Vector2 currentPosition;

    private void Start()
    {
        lastDirection.Set(-1, 0);
    }

    private void Update()
    {
        transform.position = transform.position + speed * Time.deltaTime * new Vector3(direction.x, direction.y);
        currentPosition = transform.position;
    }

    public void SetDirection(Vector2 direction)
    {
        if (!enabled) return;

        this.direction = direction;

        if (direction != Vector2.zero)
        {
            lastDirection = direction;
        }
    }
}
