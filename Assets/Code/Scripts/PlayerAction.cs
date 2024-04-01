using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    void OnDrawGizmos()
    {

        //var renderer = gameObject.GetComponent<Collider>();
        //Debug.Log("renderer: " + renderer);
        //if (renderer == null) { return; }


        //var bottom = transform.position;
        //var topVector = new Vector3(0, renderer.bounds.size.y, 0);
        //var center = bottom + topVector;
        //var radius = renderer.bounds.size.z * 1.5f;

        //Gizmos.DrawSphere(center, radius);
    }

    public void Action()
    {
        var collider = gameObject.GetComponent<Collider>();
        if (collider == null) { return; }

        var bottom = transform.position;
        var topVector = new Vector3(0, collider.bounds.size.y, 0);
        var center = bottom + topVector;
        var radius = collider.bounds.size.z * 1.5f;

        Physics.SphereCast(center, radius, transform.up, out RaycastHit hit, radius);

        Debug.Log("PlayerAction.Action");
    }
}