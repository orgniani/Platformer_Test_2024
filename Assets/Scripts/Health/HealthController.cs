using UnityEngine;

public delegate void VoidDelegateType();

public class HealthController : MonoBehaviour
{
    [SerializeField] public int HP = 1;

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
