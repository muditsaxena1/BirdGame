using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private Transform leftBuildings, rightBuildings;
    public GameObject road;
    private float nextRoadPos = 12000f;
    public GameObject[] houses;
    public int[] houseLength;

    private float nextRightHousePos = 40f, nextLeftHousePos = 20f;

    private void Start()
    {
        leftBuildings = GameObject.Find("LeftBuildings").transform;
        rightBuildings = GameObject.Find("RightBuildings").transform;
    }
    private void FixedUpdate()
    {
        if(transform.position.z > nextRoadPos)
        {
            nextRoadPos += 120f;
            Instantiate(road,new Vector3(0f,0f,nextRoadPos),Quaternion.identity);
        }
        if(transform.position.z > nextLeftHousePos)
        {
            int index = Random.Range(0, 7);
            nextLeftHousePos += houseLength[index];
            Vector3 pos = new Vector3(-55.5f, 90.84171f, nextLeftHousePos);
            GameObject house = Instantiate(houses[index],pos,Quaternion.identity) as GameObject;
            house.transform.parent = leftBuildings;
            print(index);
        }
        if (transform.position.z > nextRightHousePos)
        {
            int index = Random.Range(0, 7);
            Vector3 pos = new Vector3(-10.5f, 90.84171f, nextRightHousePos);
            nextRightHousePos += houseLength[index];
            GameObject house = Instantiate(houses[index], pos, Quaternion.Euler(0f,180f,0f)) as GameObject;
            house.transform.parent = leftBuildings;
            print(index);
        }
    }
}
