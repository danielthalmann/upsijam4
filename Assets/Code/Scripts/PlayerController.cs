using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody characterRigidbody;

    public Animator farmerAnimator;

    public float changeSpeed = 10f;
    public float speed = 10f;

    private Vector3 targetMoveVector = Vector3.zero;
    private Vector3 currentRotationVector = Vector3.zero;

    private static readonly int Walking = Animator.StringToHash("walking");

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();

        if (targetMoveVector == new Vector3(input.x, 0, input.y))
        {
            return;
        }

        targetMoveVector = new Vector3(input.x, 0, input.y);

        farmerAnimator.SetBool(Walking, input != Vector2.zero);
    }

    void FixedUpdate()
    {
        characterRigidbody.velocity = targetMoveVector * speed;

        if (transform.forward == targetMoveVector || targetMoveVector == Vector3.zero)
        {
            Debug.Log("OK");
            return;
        }

        Debug.Log("calculate");

        var diffVector = (targetMoveVector - currentRotationVector);
        if(Math.Abs(diffVector.z) > 1 && Math.Abs(diffVector.x) < 0.05f)
        {
            diffVector.x = 0.1f;
        }
        if(Math.Abs(diffVector.x) > 1f && Math.Abs(diffVector.z) < 0.05f)
        {
            diffVector.z = 0.1f;
        }

        currentRotationVector += diffVector * Time.fixedDeltaTime * changeSpeed;
        currentRotationVector.Normalize();

        transform.forward = currentRotationVector.normalized;
    }
}
