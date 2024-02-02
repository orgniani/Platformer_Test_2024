using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void VoidDelegateType();

public class HealthController : MonoBehaviour
{
    [SerializeField] private int HP = 1;

    public VoidDelegateType onHurt;
    public VoidDelegateType onDead;

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
            Die();
    }

    private void Die()
    {
        if (onDead != null)
            onDead();
    }
}
