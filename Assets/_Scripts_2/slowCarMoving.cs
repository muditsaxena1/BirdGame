using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowCarMoving : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public GameObject[] slowCars;
    // Start is called before the first frame update
    void Start()
    {
        slowCars = GameObject.FindGameObjectsWithTag("Slow_Cars");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject slowCar in slowCars)
        {
            slowCar.transform.position += slowCar.transform.forward * Time.deltaTime *
                speed;
        }
    }
}
