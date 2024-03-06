using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDeath : MonoBehaviour
{
    [SerializeField] private HealthController HP;
    [SerializeField] private float timeBeforeDestruction = 1f;

    private void OnEnable()
    {
        HP.onDead += HandleDestroy;
    }

    private void OnDisable()
    {
        HP.onDead -= HandleDestroy;
    }

    private void HandleDestroy()
    {
        Destroy(gameObject, timeBeforeDestruction);
    }
}
