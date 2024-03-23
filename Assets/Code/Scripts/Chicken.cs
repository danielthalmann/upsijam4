using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private float health;
    private Vector3 targetDirection;
    private Vector3 currentDirection;
    private float speed;
    private float rotationTimer;
    private float rotationAcc = 0;
    private bool chickenIsGrabbed = false;
    private Transform grabber;

    // Start is called before the first frame update
    public void Init(bool isInfected, Vector3 position) {
        if (isInfected) {
            health = 0;
        } else {
            health = 1;
        }

        gameObject.transform.position = position;

        targetDirection = new Vector3 (Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
        targetDirection.Normalize();
        gameObject.transform.rotation = Quaternion.LookRotation (targetDirection);

        rotationTimer = (float)(Random.Range(2000, 5000)) / 1000f;
        speed = (float)(Random.Range(2000, 4000)) / 1000f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
    }

    public void ThrowChicken()
    {
        chickenIsGrabbed = false;

        var throwDirection = new Vector3(grabber.rotation.x, 0.5f, grabber.rotation.z);

        gameObject.GetComponent<Rigidbody>().AddForce(throwDirection);

        grabber = null;
    }
}
