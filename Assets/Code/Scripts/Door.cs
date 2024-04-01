using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractive
{
    private bool open = false;
    private float targetAngle;
    private bool userIsCloseToDoor = false;

    private void Update()
    {
        if (transform.rotation.y == targetAngle)
        {
            return;
        }

        //if (System.Math.Abs(transform.rotation.y - targetAngle) < 0.1)
        //{
            transform.rotation.Set(0, targetAngle, 0, 0);
            return;
        //}
    }

    private void OnTriggerEnter(Collider collider)
    {
        var player = collider.GetComponent<PlayerController>();

        if (player != null)
        {
            userIsCloseToDoor = true;
        }
        else
        {
            userIsCloseToDoor = false;
        }
    }

    public void Action()
    {
        if(!userIsCloseToDoor)
        {
            return;
        }

        if(open)
        {
            open = false;
            targetAngle = 0;
        } else
        {
            open = true;
            targetAngle = 90;
        }
    }
}
