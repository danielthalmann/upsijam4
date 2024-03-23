using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _inputs = Vector2.zero;

    public Rigidbody characterRigidbody;

    public float characterMovementForceMultiplier = 2f;

    public void Movement(InputAction.CallbackContext context)
    {
        _inputs = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_inputs.x, 0, _inputs.y);
        Vector3 velocity = direction * 10f;

        Quaternion rotation = Quaternion.Euler(0, 45, 0);
        Vector3 isometricInput = rotation * velocity;

        characterRigidbody.MovePosition(characterRigidbody.position + (isometricInput * (Time.fixedDeltaTime * characterMovementForceMultiplier)));

        /*characterRigidbody.AddForce(
            characterRigidbody.position + (isometricInput * (Time.fixedDeltaTime * correctedMovementForceMultiplier)),
            ForceMode.VelocityChange
        );*/
    }

    private void FixedUpdate()
    {
        Move();
    }
}
