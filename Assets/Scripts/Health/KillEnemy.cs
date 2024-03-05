using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    //CHANGE THE NAME OF THIS.

    [SerializeField] private int damage = 1;
    [SerializeField] private CharacterJump jump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemyGameObject = collision.gameObject;

        if (enemyGameObject.TryGetComponent(out HealthController enemyHP))
            enemyHP.TakeDamage(damage);

        jump.JumpAfterKill();
    }
}
