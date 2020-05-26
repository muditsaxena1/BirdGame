using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class ObjectPooler : MonoBehaviour
{
    EasyObjectPool easyObjectPool;
    public Transform leftBuildings, rightBuildings, roads, streetlights, dustbins, benches;
    private float nextRoadPos = 120f, nextStreetlightPos = 40f, nextDustbinPos = 60f, nextBenchPos = 100f;
    private float nextRightHousePos = 40f, nextLeftHousePos = 20f;
    public int[] houseLength;

    Queue<GameObject> roadQ, leftBuildingsQ, rightBuildingsQ, streetlightsQ, dustbinQ, benchQ;

    private void Start()
    {
        roadQ = new Queue<GameObject>();
        leftBuildingsQ = new Queue<GameObject>();
        rightBuildingsQ = new Queue<GameObject>();
        streetlightsQ = new Queue<GameObject>();
        dustbinQ = new Queue<GameObject>();
        benchQ = new Queue<GameObject>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!easyObjectPool)
        {
            easyObjectPool = EasyObjectPool.instance;
        }
        if(benchQ.Count > 0)
        {
            if(transform.position.z > benchQ.Peek().transform.position.z)
            {
                easyObjectPool.ReturnObjectToPool(benchQ.Dequeue());
            }
        }
        if(dustbinQ.Count > 0)
        {
            if(transform.position.z > dustbinQ.Peek().transform.position.z)
            {
                easyObjectPool.ReturnObjectToPool(dustbinQ.Dequeue());
            }
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
            if (transform.position.z - 70f > rightBuildingsQ.Peek().transform.position.z)
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
        if (transform.position.z + 170f > nextRightHousePos)
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
        if(transform.position.z + 180f > nextDustbinPos)
        {
            Vector3 pos = new Vector3(-17.65125f, 91.45171f, nextDustbinPos);
            GameObject bin = easyObjectPool.GetObjectFromPool("Dustbin", pos, Quaternion.identity);
            bin.transform.parent = dustbins;
            dustbinQ.Enqueue(bin);

            pos = new Vector3(-47.75125f, 91.45171f, nextDustbinPos);
            bin = easyObjectPool.GetObjectFromPool("Dustbin", pos, Quaternion.identity);
            bin.transform.parent = dustbins;
            dustbinQ.Enqueue(bin);

            nextDustbinPos += 80f;
        }
        if (transform.position.z + 180f > nextBenchPos)
        {
            Vector3 pos = new Vector3(-52f, 91.3f, nextBenchPos);
            GameObject bench = easyObjectPool.GetObjectFromPool("Bench", pos, Quaternion.Euler(0f,90f,0f));
            bench.transform.parent = benches;
            dustbinQ.Enqueue(bench);

            pos = new Vector3(-14f, 91.3f, nextBenchPos);
            bench = easyObjectPool.GetObjectFromPool("Bench", pos, Quaternion.Euler(0f, 270f, 0f));
            bench.transform.parent = benches;
            benchQ.Enqueue(bench);

            nextBenchPos += 80f;
        }
    }
}
