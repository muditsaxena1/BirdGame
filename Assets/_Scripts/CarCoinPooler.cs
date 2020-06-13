using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class CarCoinPooler : MonoBehaviour
{
    public Transform carMoverTransform;
    public CarMover carMover;
    public float coinLevelDistance = 300f;
    float spawnAtLeastBefore = 200f;
    int level = 0, maxLevel = 4;
    float levelDistance = 200f, nextCarPos = 100f, nextCoinPos, coinLevelEnd;
    float startingZPos, distanceCovered;
    Queue<GameObject> carQ;
    EasyObjectPool easyObjectPool;
    enum States
    {
        Normal,
        Coins,
        Boost
    }
    States currState;

    // <= first == spawn 1
    // > first && <= first + second == spawn 2
    // > first + second == spawn 3
    int[] nextCarPosArr = new int[] { 200, 200, 150, 150, 100 };
    int[,] spawnType = new int[,] { {100, 0},   // spawn 1
                                    {75, 25},   // 75% chance of spawning 1, 25% spawn 2
                                    {50, 25},   // 50% spawn 1, 25% spawn 2, 25% spawn 3 
                                    {40, 30},
                                    {30, 30} };

    private void Start()
    {
        Debug.Log("##########CarCoinPooler here bitch");
        startingZPos = transform.position.z;
        carQ = new Queue<GameObject>();
        easyObjectPool = EasyObjectPool.instance;
        currState = States.Normal;
        nextCoinPos = Random.Range(1000, 1200);
        coinLevelEnd = nextCoinPos + coinLevelDistance;
    }

    void SpawnCarAtLane(int lane, float zPos, bool shifted = false)
    {
        int carIndex = Random.Range(0, 4);
        Vector3 pos = new Vector3(lane * 5.9f - 34.2f, 91.63f, zPos);
        if (shifted)
        {
            pos += Vector3.forward * 20f;
        }
        GameObject car = easyObjectPool.GetObjectFromPool("car_" + carIndex, pos, Quaternion.identity);
        car.transform.parent = carMoverTransform;
        carMover.AddCarToQueue(car);
    }

    void SpawnCoinsAtLane(int lane, float zPos, bool shifted = false)
    {
        Vector3 pos = new Vector3(lane * 5.9f - 34.2f, 92.5f, zPos);
        if (shifted)
        {
            pos += Vector3.forward * 20f;
        }
        float yRot = 0;
        for (int i = 0; i < 10; i++)
        {
            easyObjectPool.GetObjectFromPool("coin", pos, Quaternion.Euler(0f, yRot, 0f));
            yRot += 5f;
            pos += Vector3.forward * 5f;
        }
    }

    private void FixedUpdate()
    {
        distanceCovered = transform.position.z - startingZPos;
        if (nextCarPos > nextCoinPos)
        {
            nextCoinPos = nextCarPos;
            currState = States.Coins;
        }
        if (currState == States.Coins)
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnCoinsAtLane(i, startingZPos + nextCoinPos);
            }
            nextCoinPos += 100f;
            if (nextCoinPos > coinLevelEnd)
            {
                nextCarPos = nextCoinPos;
                nextCoinPos += Random.Range(1000, 1200);
                coinLevelEnd = nextCoinPos + coinLevelDistance;
                currState = States.Normal;
            }
        }
        if (currState == States.Normal && distanceCovered + spawnAtLeastBefore > nextCarPos)
        {
            //spawn Car at startingZPos + nextCarPos
            int currSpawnType = Random.Range(1, 101);

            if (currSpawnType <= spawnType[level, 0])
            {
                //spawn 1 car, pick lane & car
                int lane = Random.Range(0, 3);
                SpawnCarAtLane(lane, startingZPos + nextCarPos);
                int coinLane = Random.Range(0, 2);
                if (coinLane == 0)
                {
                    coinLane = (lane + 2) % 3;
                }
                else
                {
                    coinLane = (lane + 1) % 3;
                }
                SpawnCoinsAtLane(coinLane, startingZPos + nextCarPos);
                nextCarPos += nextCarPosArr[level];
            }
            else if (currSpawnType > spawnType[level, 0] && currSpawnType <= spawnType[level, 0] + spawnType[level, 1])
            {
                //spawn 2 cars
                int lane = Random.Range(0, 3);
                SpawnCarAtLane((lane + 1) % 3, startingZPos + nextCarPos);
                SpawnCarAtLane((lane + 2) % 3, startingZPos + nextCarPos);
                SpawnCoinsAtLane(lane, startingZPos + nextCarPos);
                nextCarPos += nextCarPosArr[level];
            }
            else
            {
                //spawn 3 cars
                int lane = Random.Range(0, 3);
                SpawnCarAtLane(lane, startingZPos + nextCarPos, true);
                SpawnCarAtLane((lane + 1) % 3, startingZPos + nextCarPos);
                SpawnCarAtLane((lane + 2) % 3, startingZPos + nextCarPos);
                nextCarPos += nextCarPosArr[level];
            }
            //easyObjectPool.GetObjectFromPool("car_" + index,)
        }

        if (levelDistance * (level + 1) < distanceCovered)
        {
            if (level < maxLevel)
            {
                level++;
            }
        }
    }


}