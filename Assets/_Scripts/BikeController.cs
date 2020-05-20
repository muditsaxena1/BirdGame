using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{

    public float forceZ = 3f, forceX = 3f;
    private Rigidbody rb;
    private float xInpt;

    
    private float speedZ;
    [SerializeField]
    float maxSpeed = 6f, maxRotation = 0.05f;
    private float rotationZ;
    [SerializeField]
    float tilt = 1f;

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
        Vector3 forceDir = Vector3.zero;
        speedZ = rb.velocity.z;
        rotationZ = rb.rotation.z;
        if (rb.velocity.z < maxSpeed)
        {
            forceDir.z = forceZ * Time.deltaTime;
        }
        forceDir.x = xInpt * forceX * Time.deltaTime;
        print(forceDir);
        rb.AddForce(forceDir,ForceMode.Acceleration);

        float zRotation = rb.velocity.x * -tilt;
        zRotation = Mathf.Clamp(zRotation, -maxRotation, maxRotation);
        rb.rotation = Quaternion.Euler(0f, 0f, zRotation);
    }
}
