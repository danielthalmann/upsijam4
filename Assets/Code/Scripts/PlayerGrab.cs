using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    private Chicken grabbedChicken;
    public string[] grabbableLayers;
    private int chickenLayer;
    public Animator animator;

    void Start()
    {
        chickenLayer = LayerMask.GetMask(grabbableLayers);
    }

    public void HandleChicken(InputAction.CallbackContext context)
    {

        var value = context.ReadValue<float>();

        if(grabbedChicken == null)
        {
            GrabChicken();
        } else
        {
            PlaceChicken();
        }
    }

    void OnDrawGizmos()
    {
    }

    private void GrabChicken()
    {
        var offset = new Vector3(0, 0.5f, 0);
        var center = transform.position + offset + transform.forward * 0.5f;
        var radius = 1f;

        var hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var collider in hitColliders)
        {
            var chicken = collider.GetComponent<Chicken>();
            if (chicken != null)
            {
                Transform transform = GameObject.Find("ChickenPosition").transform;
                chicken.GrabChicken(transform);
                grabbedChicken = chicken;
                break;
            }
            
        }
    }
    
    private void PlaceChicken()
    {
        grabbedChicken.PlaceChicken();
        grabbedChicken = null;
    }
}
