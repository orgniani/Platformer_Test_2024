using UnityEngine;

public class TrapBackAndForthMovement : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    private void Update()
    {
        Vector2 targetPoint = waypoints[currentWaypointIndex].transform.position;

        if (waypoints == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            float targetDistance = Vector2.Distance(transform.position, targetPoint);

            if (targetDistance < .1f)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }

            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = targetPoint;

            Vector2 directionToNextPos = nextPosition - currentPosition;
            directionToNextPos.Normalize();

            characterMovement.SetDirection(directionToNextPos);
        }
    }
}
