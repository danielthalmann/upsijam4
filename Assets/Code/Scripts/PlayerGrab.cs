using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    private Chicken grabbedChicken;
    private static float maxForce = 2_000;
    private static float initalForce = 500;
    private float accumulatedForce = initalForce;
    private bool accumulatingForce = false;
    public Collider grabCollider;

    // Start is called before the first frame update
    void Start()
    {
        accumulatedForce = initalForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void HandleChicken(InputAction.CallbackContext context)
    {
      var value = context.ReadValue<float>();

        if(value == 1)
        {
            if (grabbedChicken != null)
            {
                accumulatingForce = true;
            }
            return;
        }

     if(grabbedChicken == null)
        {
            GrabChicken();
        } else
        {
            ThrowChicken();
        }
    }

    private void FixedUpdate()
    {
        if(accumulatingForce && accumulatedForce < maxForce) {
            accumulatedForce += Time.fixedDeltaTime * maxForce / 3;
        }
    }

    private void GrabChicken()
    {
        var offset = new Vector3(0, 0.5f, 0.01f);
        
        if (Physics.BoxCast((transform.position + offset), new Vector3(0.01f, 1f, 0.01f), transform.forward, out RaycastHit hit)) 
        {
           var chicken = hit.collider.GetComponent<Chicken>();

            if (chicken != null)
            {
                Transform transform = GameObject.Find("ChickenPosition").transform;
                chicken.GrabChicken(transform);
                grabbedChicken = chicken;
            }
        }
    }
    
    private void ThrowChicken()
    {
        grabbedChicken.ThrowChicken(accumulatedForce);
        accumulatingForce = false;
        accumulatedForce = initalForce;
        grabbedChicken = null;
    }
}
