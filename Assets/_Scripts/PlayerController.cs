using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float minX = -2, maxX = 2, minY = -2, maxY = 0;
    [SerializeField]
    float maxSpeed = 6f, maxRotation = 30f;
    [SerializeField]
    float tilt = 1f;
    [SerializeField]
    float force = 2f;
    [SerializeField]
    float dampingFactor = 0.92f;


    void FixedUpdate()
    {
        //Debug.Log("y=" + this.transform.position.y);
        float horInpt = Input.GetAxisRaw("Horizontal");
        float verInpt = Input.GetAxisRaw("Vertical");
        Rigidbody myRigidbody = this.GetComponent<Rigidbody>();

        if(horInpt > 0 && this.transform.position.x < maxX)
        {
            if (myRigidbody.velocity.x < maxSpeed)
            {
                myRigidbody.AddForce(force, 0f, 0f);
            }
        }
        else if(horInpt < 0 && this.transform.position.x > minX)
        {
            if (-myRigidbody.velocity.x < maxSpeed)
            {
                myRigidbody.AddForce(-force, 0f, 0f);
            }
        }
        else
        {
            Vector3 vel = myRigidbody.velocity;
            vel.x *= dampingFactor;
            //vel.y *= dampingFactor;
            myRigidbody.velocity = vel;
        }

        if(verInpt > 0)
        {
            if (myRigidbody.velocity.y < maxSpeed && this.transform.position.y < maxY)
            {
                myRigidbody.AddForce(0f, force, 0f);
            }
        }
        else if(verInpt < 0)
        {
            if (-myRigidbody.velocity.x < maxSpeed && this.transform.position.y > minY)
            {
                myRigidbody.AddForce(0f, -force, 0f);
            }
        }
        else
        {
            Vector3 vel = myRigidbody.velocity;
            //vel.x *= dampingFactor;
            vel.y *= dampingFactor;
            myRigidbody.velocity = vel;
        }
        float zRotation = myRigidbody.velocity.x * -tilt;
        float xRotation = myRigidbody.velocity.y * -tilt;
        xRotation = Mathf.Clamp(xRotation, -maxRotation, maxRotation);
        zRotation = Mathf.Clamp(zRotation, -maxRotation, maxRotation);
        myRigidbody.rotation = Quaternion.Euler(xRotation, 0f, zRotation);
        ///Debug.Log("Rotation = " + myRigidbody.velocity.x * -tilt);

        //Making sure player does not moves out of the screen
        Vector3 temp = this.transform.position;
        temp.x = Mathf.Clamp(temp.x, minX, maxX);
        temp.y = Mathf.Clamp(temp.y, minY, maxY);
        this.transform.position = temp;
    }
}
