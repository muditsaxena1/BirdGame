using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(0f,0f, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bike")
        {
            Debug.LogWarning("Crashed Bitch");
        }
    }
}

