using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField]
    float speed = 4f, acceleration = 0.2f, maxSpeed = 10f;


    void FixedUpdate()
    {
        Vector3 temp = this.transform.position;
        temp.z += speed * Time.deltaTime;
        this.transform.position = temp;
        speed += acceleration * Time.deltaTime;
        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
