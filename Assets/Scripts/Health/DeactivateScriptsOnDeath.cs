using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateScriptsOnDeath : MonoBehaviour
{
    [SerializeField] private HealthController HP;
    [SerializeField] private Collider2D col;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Rigidbody2D rigidbody2D;

    private void OnEnable()
    {
        HP.onDead += HandleDeath;
    }

    private void OnDisable()
    {
        HP.onDead -= HandleDeath;
    }

    private void HandleDeath()
    {
        if (col != null)
            col.enabled = false;

        if (characterMovement != null)
            characterMovement.enabled = false;

        if (rigidbody2D != null)
            rigidbody2D.bodyType = RigidbodyType2D.Static;
    }
}
