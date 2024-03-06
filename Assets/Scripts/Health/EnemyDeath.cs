using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] HealthController healthController;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 0.5f;
    [SerializeField] private float speed = 0.5f;
    private bool isDead = false;

    private void OnEnable()
    {
        healthController.onDead += HandleEnemyDeath;
    }

    private void OnDisable()
    {
        healthController.onDead -= HandleEnemyDeath;
    }

    private void HandleEnemyDeath()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        isDead = true;

    }

    private void Update()
    {
        if(isDead)
        {
            transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        }
    }
}
