using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterJump characterJump;

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        if (!characterMovement)
            return;

        Vector2 inputValue = inputContext.ReadValue<Vector2>();
        characterMovement.SetDirection(inputValue);
    }

    public void Jump(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started)
        {
            characterJump.Jump();
        }
    }
}
