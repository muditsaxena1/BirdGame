using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Building")
        {
            Destroy(other.gameObject);
        }
        else if(other.tag == "Road")
        {
            other.gameObject.SetActive(false);
            Vector3 pos = other.gameObject.transform.position;
            other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + 120f);
            other.gameObject.SetActive(true);
        }
        //buildings
    }
}
