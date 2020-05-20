using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeRespawner : MonoBehaviour
{
    float lastTerrainZ;
    [SerializeField]
    float terrainSize = 20f;
    void Start()
    {
        GameObject[] terrains = GameObject.FindGameObjectsWithTag("Terrain");
        lastTerrainZ = terrains[0].transform.position.z;
        for (int i = 0; i < terrains.Length; i++)
        {
            if (lastTerrainZ < terrains[i].transform.position.z)
            {
                lastTerrainZ = terrains[i].transform.position.z;
            }
            float angle = Random.Range(0, 3) * 90;
            terrains[i].transform.Rotate(new Vector3(0f, angle, 0f));

        }
    }

    private void OnTriggerEnter(Collider target)
    {
        //Debug.Log("Collided with " + target.name);
        if(target.tag == "Terrain")
        {
            Vector3 temp = target.transform.position;
            lastTerrainZ += terrainSize;
            temp.z = lastTerrainZ;
            target.transform.position = temp;

            int angle = Random.Range(0, 3) * 90;
            target.transform.Rotate(new Vector3(0f, angle, 0f));
        }
    }
}
