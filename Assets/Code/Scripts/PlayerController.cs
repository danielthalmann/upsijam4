using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _inputs = Vector2.zero;

    public Rigidbody characterRigidbody;

    public Animator farmerAnimator;

    public float characterMovementForceMultiplier = 2f;

    private static readonly int Walking = Animator.StringToHash("walking");

    public void Movement(InputAction.CallbackContext context)
    {
        _inputs = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        characterRigidbody.MovePosition(
            characterRigidbody.position + (GetIsometricInputs() * (Time.fixedDeltaTime * characterMovementForceMultiplier))
        );
    }

    private void Rotate()
    {
        if (_inputs != Vector2.zero)
        {
            var isometricInput = GetIsometricInputs();
            var position = transform.position;

            var relativePosition = (position + isometricInput) - position;
            var playerRotation = Quaternion.LookRotation(relativePosition, Vector3.up);

            characterRigidbody.MoveRotation(playerRotation);
        }
    }

    private void Update()
    {
        ChangeAnimationStateWalking(_inputs != Vector2.zero);
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private Vector3 GetIsometricInputs()
    {
        Vector3 direction = new Vector3(_inputs.x, 0, _inputs.y);
        Vector3 velocity = direction * 10f;

        Quaternion rotation = Quaternion.Euler(0, 45, 0);
        Vector3 isometricInput = rotation * velocity;

        return isometricInput;
    }

    private void ChangeAnimationStateWalking(bool state)
    {
        farmerAnimator.SetBool(Walking, state);
    }
}
