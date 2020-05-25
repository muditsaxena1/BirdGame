using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class ObjectPooler : MonoBehaviour
{
    EasyObjectPool easyObjectPool;
    public Transform leftBuildings, rightBuildings, roads, streetlights;
    private float nextRoadPos = 120f, nextStreetlightPos = 40f;
    private float nextRightHousePos = 40f, nextLeftHousePos = 20f;
    public int[] houseLength;

    Queue<GameObject> roadQ, leftBuildingsQ, rightBuildingsQ, streetlightsQ;

    private void Start()
    {
        roadQ = new Queue<GameObject>();
        leftBuildingsQ = new Queue<GameObject>();
        rightBuildingsQ = new Queue<GameObject>();
        streetlightsQ = new Queue<GameObject>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!easyObjectPool)
        {
            easyObjectPool = EasyObjectPool.instance;
        }
        if(streetlightsQ.Count > 0)
        {
            if(transform.position.z > streetlightsQ.Peek().transform.position.z)
            {
                easyObjectPool.ReturnObjectToPool(streetlightsQ.Dequeue());
            }
        }

        if (roadQ.Count > 0)
        {
            if (transform.position.z + 80f > roadQ.Peek().transform.position.z)
            {
                easyObjectPool.ReturnObjectToPool(roadQ.Dequeue());
            }
        }
        if (leftBuildingsQ.Count > 0)
        {
            if (transform.position.z - 10f > leftBuildingsQ.Peek().transform.position.z)
            {
                easyObjectPool.ReturnObjectToPool(leftBuildingsQ.Dequeue());
            }
        }
        if (rightBuildingsQ.Count > 0)
        {
            if (transform.position.z - 60f > rightBuildingsQ.Peek().transform.position.z)
            {
                easyObjectPool.ReturnObjectToPool(rightBuildingsQ.Dequeue());
            }
        }
        if (transform.position.z + 240f > nextRoadPos)
        {
            nextRoadPos += 120f;
            GameObject road = easyObjectPool.GetObjectFromPool("Road", new Vector3(0f, 0f, nextRoadPos), Quaternion.identity);
            road.transform.parent = roads;
            roadQ.Enqueue(road);
        }
        if (transform.position.z + 180f > nextLeftHousePos)
        {
            int index = Random.Range(0, 7);
            nextLeftHousePos += houseLength[index];
            Vector3 pos = new Vector3(-55.5f, 90.84171f, nextLeftHousePos);
            GameObject house = easyObjectPool.GetObjectFromPool("Building_" + (index + 1), pos, Quaternion.identity);
            house.transform.parent = leftBuildings;
            leftBuildingsQ.Enqueue(house);
            //print(index);
        }
        if (transform.position.z + 180f > nextRightHousePos)
        {
            int index = Random.Range(0, 7);
            Vector3 pos = new Vector3(-10.5f, 90.84171f, nextRightHousePos);
            nextRightHousePos += houseLength[index];
            GameObject house = easyObjectPool.GetObjectFromPool("Building_" + (index + 1), pos, Quaternion.Euler(0f, 180f, 0f));
            house.transform.parent = leftBuildings;
            leftBuildingsQ.Enqueue(house);
            //print(index);
        }
        if(transform.position.z + 180f > nextStreetlightPos)
        {
            Vector3 pos = new Vector3(-19f,91.5f, nextStreetlightPos);
            GameObject slight = easyObjectPool.GetObjectFromPool("Streetlight", pos, Quaternion.identity);
            slight.transform.parent = streetlights;
            streetlightsQ.Enqueue(slight);

            pos = new Vector3(-46.8f, 91.5f, nextStreetlightPos);
            slight = easyObjectPool.GetObjectFromPool("Streetlight", pos, Quaternion.Euler(0f, 180f, 0f));
            slight.transform.parent = streetlights;
            streetlightsQ.Enqueue(slight);

            nextStreetlightPos += 40f;
        }
    }
}
