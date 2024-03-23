using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    private Chicken[] chickens;
    private IsolatedArea[] isolatedAreas;
    private float checkCountdown = 0;
    private float checkFrenquency = 2;

    public Field field;

    // Start is called before the first frame update
    public void Init()
    {
        isolatedAreas = FindObjectsOfType<IsolatedArea>();
        chickens = FindObjectsOfType<Chicken>();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkCountdown > 0)
        {
            checkCountdown -= Time.deltaTime;
            return;
        }

        checkCountdown = checkFrenquency;

        var dictionary = new Dictionary<int, HashSet<Chicken>>();

        dictionary.Add(field.GetInstanceID(), new HashSet<Chicken>());

        foreach (var chicken in chickens)
        {
            var foundArea = false;

            var chickenBounds = chicken.GetComponent<Collider>().bounds;
            chickenBounds.center = chicken.transform.position;

            foreach (var isolatedArea in isolatedAreas) { 
                if(isolatedArea.IsIntersecting(chickenBounds))
                {
                    if(!dictionary.ContainsKey(isolatedArea.GetInstanceID()))
                    {
                        dictionary.Add(isolatedArea.GetInstanceID(), new HashSet<Chicken>());
                    }

                    dictionary[isolatedArea.GetInstanceID()].Add(chicken);
                    foundArea = true;
                    break;
                }
            }

            if(!foundArea)
            {
                dictionary[field.GetInstanceID()].Add(chicken);
            }
        }

        if (dictionary[field.GetInstanceID()].Count != 0)
        {
            var infectionState = dictionary[field.GetInstanceID()].First().IsInfected();
            foreach (var chicken in dictionary[field.GetInstanceID()])
            {
                if (chicken.IsInfected() != infectionState)
                {
                    return;
                }
            }
        }

        // if not mixed, check if at least one area has only healthy chickens -> WIN : LOSE
        foreach (var area in dictionary)
        {
            var safeArea = true;
            foreach (var chicken in area.Value)
            {
                if(chicken.IsInfected())
                {
                    safeArea = false;
                    break;
                }
            }

            if(safeArea)
            {
                // GO TO WINNING SCENE
                Debug.Log("WIN");
                return;
            }
        }

        // GO TO LOSE SCENE
        Debug.Log("LOSE");
    }
}
