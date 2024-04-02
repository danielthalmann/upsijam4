using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private float health = 1;
    private Vector3 targetDirection;
    public float speedMin = 1;
    public float speedMax = 5;
    private bool chickenIsGrabbed = false;
    private Transform grabber;
    private bool isInfected = false;

    public float maxTimeToBite = 5;
    private float timeToBite = 0;

    public GameObject niceChickenObject;
    public GameObject badChickenObject;
    public GameObject infectedChickenObject;
    public float timeToTurn = 2;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    public void Init(bool isInfected, Vector3 position) {
        this.isInfected = isInfected;
        timeToTurn = Random.Range(5, 15);

        gameObject.transform.position = position;

        targetDirection = new Vector3 (Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        targetDirection.Normalize();
        gameObject.transform.rotation = Quaternion.LookRotation (targetDirection);

        badChickenObject.SetActive(false);
        infectedChickenObject.SetActive(false);

        rigidBody = GetComponent<Rigidbody>();
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

        if(Random.Range(0f, 1f) > 0.99)
        {
            targetDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        }

        var diff = targetDirection - transform.forward;
        if(diff.magnitude > 0.1f) {
            transform.forward += (targetDirection - transform.forward).normalized * 10 * Time.fixedDeltaTime;
        }

        rigidBody.velocity = targetDirection * Random.Range(speedMin, speedMax);
    }

    public void GrabChicken(Transform transform)
    {
        chickenIsGrabbed = true;
        grabber = transform;
    }

    public void PlaceChicken()
    {
        chickenIsGrabbed = false;
        grabber = null;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
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
