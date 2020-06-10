using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class CarMover : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;
    int frameNum = 0;
    public Transform playerT;
    Queue<GameObject> spawnedCars;
    EasyObjectPool easyObjectPool;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        spawnedCars = new Queue<GameObject>();
        easyObjectPool = EasyObjectPool.instance;
    }

    public void AddCarToQueue(GameObject car)
    {
        spawnedCars.Enqueue(car);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(0f,0f, speed * Time.deltaTime));
        if(spawnedCars.Count > 0 && spawnedCars.Peek().transform.position.z + 10f < playerT.position.z)
        {
            easyObjectPool.ReturnObjectToPool(spawnedCars.Peek());
            spawnedCars.Dequeue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bike")
        {
            Debug.LogWarning("Crashed Bitch");
        }
    }
}

