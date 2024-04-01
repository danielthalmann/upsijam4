using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private float health = 1;
    private Vector3 targetDirection;
    private Vector3 currentDirection;
    private float speed;
    private float rotationTimer;
    private float rotationAcc = 0;
    private bool chickenIsGrabbed = false;
    private Transform grabber;
    private bool isInfected = false;

    public float maxTimeToBite = 5;
    private float timeToBite = 0;

    public GameObject niceChickenObject;
    public GameObject badChickenObject;
    public GameObject infectedChickenObject;
    public float timeToTurn = 2;

    // Start is called before the first frame update
    public void Init(bool isInfected, Vector3 position) {
        this.isInfected = isInfected;
        timeToTurn = Random.Range(5, 15);

        gameObject.transform.position = position;

        targetDirection = new Vector3 (Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        targetDirection.Normalize();
        gameObject.transform.rotation = Quaternion.LookRotation (targetDirection);

        rotationTimer = (float)(Random.Range(2000, 5000)) / 1000f;
        speed = (float)(Random.Range(1000, 2000)) / 1000f;

        badChickenObject.SetActive(false);
        infectedChickenObject.SetActive(false);
    }

    private void Update()
    {
        if(isInfected && health > 0)
        {
            if (!infectedChickenObject)
            {
                niceChickenObject.SetActive(false);
                badChickenObject.SetActive(false);
                infectedChickenObject.SetActive(true);
            }
            health = (float) System.Math.Max (health - (Time.deltaTime / timeToTurn), 0);
        }

        if(health > 0 && !niceChickenObject.activeSelf)
        {
            niceChickenObject.SetActive(true);
            badChickenObject.SetActive(false);
            infectedChickenObject.SetActive(false);
        } else if(health == 0 && !badChickenObject.activeSelf)
        {
            infectedChickenObject.SetActive(false);
            badChickenObject.SetActive(true);
            niceChickenObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsInfected() && !IsContagious())
        {
            return;
        }

        timeToBite -= Time.deltaTime;

        if(chickenIsGrabbed && grabber != null)
        {
            gameObject.transform.position = grabber.position;
            gameObject.transform.rotation = grabber.rotation;

            return;
        }

        rotationAcc += Time.deltaTime;

        if (rotationAcc > rotationTimer)
        {
            rotationAcc = 0;
            targetDirection = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
            targetDirection.Normalize ();
        }

        currentDirection = targetDirection + (currentDirection * (float)(System.Math.Pow(System.Math.E, -0.1 * rotationAcc)));

        gameObject.transform.position += targetDirection * speed * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.LookRotation(currentDirection);
    }

    public void GrabChicken(Transform transform)
    {
        chickenIsGrabbed = true;
        grabber = transform;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    public void PlaceChicken()
    {
        chickenIsGrabbed = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        grabber = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isInfected)
        {
            return;
        }
        var otherChicken = collision.gameObject.GetComponent<Chicken>();

        if (otherChicken == null)
        {
            return;
        }

        if (otherChicken.IsContagious() && otherChicken.CanBite())
        {
            isInfected = true;
            otherChicken.HasBiten();
        }
    }

    public void HasBiten()
    {
        timeToBite = maxTimeToBite;
    }

    public bool IsContagious()
    {
        return health == 0;
    }

    public bool CanBite()
    {
        return timeToBite <= 0;
    }

    public bool IsInfected()
    {
        return isInfected;
    }
}
