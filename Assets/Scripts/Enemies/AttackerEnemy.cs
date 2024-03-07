using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerEnemy : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;

    [SerializeField] private float waitToAttack = 0.5f;
    [SerializeField] private float attackCooldown = 1f;
    private bool shouldAttack = true;

    [SerializeField] private int damage = 1;

    [SerializeField] private LayerMask playerLayer;

    public VoidDelegateType onAttack;

    private void Update()
    {
        if (!shouldAttack) return;

        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        shouldAttack = false;

        if (onAttack != null) onAttack();
        StartCoroutine(AttackSequence());

        yield return new WaitForSeconds(attackCooldown);

        shouldAttack = true;
    }

    private IEnumerator AttackSequence()
    {
        yield return new WaitForSeconds(waitToAttack);

        Collider2D[] hitPlayer = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(3, 4), attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            if (player.TryGetComponent(out HealthController HP))
            {
                HP.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (!attackPoint) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
