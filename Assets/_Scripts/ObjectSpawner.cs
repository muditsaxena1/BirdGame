using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject road;
    private float nextRoadPos = 120f;
    public GameObject[] houses;

    private void Awake()
    {
        print(transform.position);
    }

    private void FixedUpdate()
    {
        if(transform.position.z > nextRoadPos)
        {
            nextRoadPos += 120f;
            Instantiate(road,new Vector3(0f,0f,nextRoadPos),Quaternion.identity);
        }
    }
}
