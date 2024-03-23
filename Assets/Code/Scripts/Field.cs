using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Chicken chicken;
    public uint chickenCount;
    public Enclosure[] enclosures;
    public GameStats stats;

    // Start is called before the first frame update
    void Start()
    {
        var fieldPosition = GetComponent<Renderer>().bounds.size / 2;

        var enclosures = FindObjectsOfType<Enclosure>();

        for (uint i = 0; i < chickenCount; i++)
        {
            var newChicken = Instantiate(chicken);

            Vector3 chickenPosition;
            Bounds chickenBounds;

            do
            {
                chickenPosition = new Vector3(Random.Range(-fieldPosition.x, fieldPosition.x), 0, Random.Range(-fieldPosition.z, fieldPosition.z));
                chickenPosition += gameObject.transform.position;
                chickenBounds = newChicken.GetComponent<Collider>().bounds;
                chickenBounds.center += chickenPosition;
            } while (IsIntersecting(chickenBounds, enclosures));

            newChicken.Init(i < chickenCount / 10, chickenPosition);
        }

        stats.Init();
    }

    bool IsIntersecting(Bounds chickenBounds, Enclosure[] enclosures)
    {
        foreach (var enclosure in enclosures)
        {
            if (enclosure.IsIntersecting(chickenBounds))
            {
                return true;
            }
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
