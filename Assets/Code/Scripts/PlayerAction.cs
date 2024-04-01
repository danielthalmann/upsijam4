using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    void OnDrawGizmos()
    {

    }

    public void Action(InputAction.CallbackContext context)
    {
        var playerCollider = gameObject.GetComponent<Collider>();
        if (playerCollider == null) { return; }

        var input = context.ReadValue<float>();

        if(input == 1) { return; }

        var bottom = transform.position;
        var topVector = new Vector3(0, playerCollider.bounds.size.y, 0);
        var center = bottom + topVector;
        var radius = playerCollider.bounds.size.z * 1.5f;

        var colliders = Physics.OverlapSphere(center, radius);

        foreach(var collider in colliders)
        {
            var door = collider.GetComponent<Door>();

            if(door != null)
            {
                door.Action();
                return;
            }
        }

        Debug.Log("PlayerAction.Action");
    }
}