using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{

    public float forceZ = 3f, forceX = 3f;
    private float speedZ, speedX;
    [SerializeField]
    float maxSpeedZ = 25f, maxSpeedX = 10f, maxRotation = 0.05f;
    public float dampingFactor = 0.99f;

    private Rigidbody rb;
    private Vector3 speed;

    private float xInpt;
    private float rotationZ;
    [SerializeField]
    float tilt = 1f;
    public float changeDirectionFactor = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        xInpt = Input.GetAxis("Horizontal");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Velocities
        if (speedZ < maxSpeedZ)
        {
            speedZ += forceZ * Time.deltaTime;
        }

        // X speed
        if (xInpt > 0 && speedX < 0)
        {
            Debug.Log("CHanging dir");
            speedX += forceX * Time.deltaTime * changeDirectionFactor;
        }
        else if (xInpt > 0 && speedX < maxSpeedX)
        {
            speedX += forceX * Time.deltaTime;
        }
        else if (xInpt < 0 && speedX > 0)
        {
            Debug.Log("CHanging dir");
            speedX -= forceX * Time.deltaTime * changeDirectionFactor;
        }
        else if(xInpt < 0 && speedX > -maxSpeedX)
        {
            speedX -= forceX * Time.deltaTime;
        }
        else if(xInpt == 0)
        {
            speedX = speedX * dampingFactor;
        }
        speed = new Vector3(speedX, 0f, speedZ);
        rb.MovePosition(transform.position + speed * Time.deltaTime);


        //Rotation
        float rotation = speedX * -tilt * Time.deltaTime;
        rotation = rotationZ = Mathf.Clamp(rotation, -maxRotation, maxRotation);
        rb.rotation = Quaternion.Euler(0f, 0f, rotation);






        //Vector3 forceDir = Vector3.zero;
        //speedZ = rb.velocity.z;
        //rotationZ = rb.rotation.z;
        //if (rb.velocity.z < maxSpeed)
        //{
        //    forceDir.z = forceZ * Time.deltaTime;
        //}
        //forceDir.x = xInpt * forceX * Time.deltaTime;
        //print(forceDir);
        //rb.AddForce(forceDir,ForceMode.Acceleration);

        //float zRotation = rb.velocity.x * -tilt;
        //zRotation = Mathf.Clamp(zRotation, -maxRotation, maxRotation);
        //rb.rotation = Quaternion.Euler(0f, 0f, zRotation);
    }
}
