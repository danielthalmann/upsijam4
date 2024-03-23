using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public bool IsIntersecting(Bounds bounds)
    {
        var myBounds = GetComponent<Collider>().bounds;
        myBounds.center = gameObject.transform.position;

        return myBounds.Intersects(bounds);
    }
}
