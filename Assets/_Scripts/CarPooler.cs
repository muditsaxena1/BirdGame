using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class CarPooler : MonoBehaviour
{
    public float spawnAtLeastBefore = 100f;
    int level = 0, maxLevel = 5;
    float levelDistance = 200f, nextCarPos = 100f;
    float startingZPos, distanceCovered;
    Queue<GameObject> carQ;
    EasyObjectPool easyObjectPool;

    private void Start()
    {
        startingZPos = transform.position.z;
        carQ = new Queue<GameObject>();
        easyObjectPool = EasyObjectPool.instance;
    }

    private void FixedUpdate()
    {
        distanceCovered = transform.position.z - startingZPos;
        if(distanceCovered + spawnAtLeastBefore > nextCarPos)
        {
            //spawn Car at startingZPos + nextCarPos
            int index = Random.Range(1, 5);
            //easyObjectPool.GetObjectFromPool("car_" + index,)
        }

        if(levelDistance * (level + 1) < distanceCovered)
        {
            if(level < maxLevel)
            {
                level++;
            }
        }
    }


}
