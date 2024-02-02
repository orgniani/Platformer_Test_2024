using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject playerGameObject = collision.gameObject;

        if (playerGameObject.TryGetComponent(out HealthController playerHP))
            playerHP.TakeDamage(damage);
    }
}
