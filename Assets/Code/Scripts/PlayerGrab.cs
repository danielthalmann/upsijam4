using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrabChicken()
    {        

        //var raycast = Physics.Raycast(transform.position, vectordir, out RaycastHit hit);

        Debug.DrawRay(transform.position, transform.forward);

        //if (Physics.Raycast(transform.position, vectordir, out RaycastHit hit))
        //{

        //}
    }
}
