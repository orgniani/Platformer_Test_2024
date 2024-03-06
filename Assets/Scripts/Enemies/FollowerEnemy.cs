using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterMovement targetPosition;
    [SerializeField] private TrapBackAndForthMovement trapBackAndForthMovement;

    [SerializeField] private float fasterSpeed = 4f;

    private float targetDistance;
    public bool shouldFollowTarget = false;
    [SerializeField] private float startFollowingDistance = 4f;

    private bool directionLocked = false;

    public int attackNumber = 2;

    public VoidDelegateType onReplaceSprite;

    private void Update()
    {
        if (targetPosition == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            targetDistance = Vector2.Distance(transform.position, targetPosition.transform.position);

            if (targetDistance < startFollowingDistance)
            {
                shouldFollowTarget = true;
            }

            else
            {
                shouldFollowTarget = false;
            }

            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        Vector2 nextPosition = -targetPosition.lastDirection;
        nextPosition.Normalize();

        if (shouldFollowTarget && !directionLocked)
        {
            trapBackAndForthMovement.enabled = false;
            characterMovement.speed = fasterSpeed;
            characterMovement.SetDirection(nextPosition);
            directionLocked = true;

            attackNumber = 1;
            if (onReplaceSprite != null)
                onReplaceSprite();
        }
    }
}
