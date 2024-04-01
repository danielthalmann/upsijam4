using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody characterRigidbody;

    public Animator farmerAnimator;

    public float turningSpeed = 0.01f;
    public float speed = 10f;

    private float turn = 0;
    private float advance = 0;

    private static readonly int Walking = Animator.StringToHash("walking");

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();

        turn = input.x;

        if(turn != 0)
        {
            // transforms float into +1 or -1
            turn /= Math.Abs(turn);
        }

        advance = input.y;

        if(advance != 0)
        {
            // transforms float into +1 or -1
            advance /= Math.Abs(advance);
        }

        farmerAnimator.SetBool(Walking, input != Vector2.zero);
    }

    void FixedUpdate()
    {
        if (turn != 0) {
            transform.forward = Quaternion.Euler(0, 180 * Time.fixedDeltaTime * turningSpeed * turn, 0) * transform.forward;
        }

        if (advance != 0 || characterRigidbody.velocity != Vector3.zero)
        {
            characterRigidbody.velocity = transform.forward * speed * advance;
        }
    }
}
