using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enclosure : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsIntersecting(Bounds bounds)
    {
        var myBounds= GetComponent<Collider>().bounds;
        myBounds.center = gameObject.transform.position;

        return myBounds.Intersects(bounds);
    }
}
