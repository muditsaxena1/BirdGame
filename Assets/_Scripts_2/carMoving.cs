using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMoving : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public GameObject[] fastCars;
    // Start is called before the first frame update
    void Start()
    {
        fastCars = GameObject.FindGameObjectsWithTag("Fast_Cars");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject fastCar in fastCars) {
            fastCar.transform.position += fastCar.transform.forward * Time.deltaTime *
                speed; }
    }
}
