using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 startingPosition;
    public Transform bike;
    // Start is called before the first frame update
    void Start()
    {
        bike = GameObject.FindGameObjectWithTag("Bike").transform;
        startingPosition = transform.position - bike.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startingPosition + bike.position;
    }
}
