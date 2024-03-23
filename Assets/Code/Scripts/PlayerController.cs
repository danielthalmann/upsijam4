using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _inputs = Vector2.zero;

    public CharacterController characterController;
    public Rigidbody characterRigidbody;

    public float speed = 10f;

    public void Movement(InputAction.CallbackContext context)
    {
        _inputs = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        /*Vector3 direction = new Vector3(_inputs.x, 0, _inputs.y);
        Vector3 velocity = direction * speed;

        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));
        var isometricInput = matrix.MultiplyPoint3x4(velocity * Time.deltaTime);
*/
        // characterController.Move(transform.TransformDirection(isometricInput));

        Vector3 direction = new Vector3(_inputs.x, 0, _inputs.y);
        Vector3 velocity = direction * speed;

        Quaternion rotation = Quaternion.Euler(0, 45, 0);
        Vector3 isometricInput = rotation * velocity;

        // Debug.Log($"Input: {_inputs}, Direction: {direction}, Velocity: {velocity}, Final Position: {characterRigidbody.position + isometricInput * Time.fixedDeltaTime}");

        characterRigidbody.AddForce(characterRigidbody.position + isometricInput, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
