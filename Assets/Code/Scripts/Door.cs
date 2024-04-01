using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractive
{
    private Animator myDoor = null;
    private bool doorIsOpen = false;

    void Start()
    {
        myDoor = GetComponent<Animator>();
    }

    public void Action()
    {
        // return if animation is playing
        if(
            myDoor.GetCurrentAnimatorStateInfo(0).length > 
            myDoor.GetCurrentAnimatorStateInfo(0).normalizedTime
        )
        {
            return;
        }

        if (doorIsOpen)
        {
            myDoor.Play("DoorClose", 0, 0);
            doorIsOpen = false;
        } else {
            myDoor.Play("DoorOpen", 0, 0);
            doorIsOpen = true;
        }
    }
}
