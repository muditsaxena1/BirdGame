using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMoving : MonoBehaviour
{
    [SerializeField]
    public float speed;
     GameObject[] fastCars;
    Rigidbody[] fastcar;
    
    // Start is called before the first frame update
    void Start()
    {
        fastCars = GameObject.FindGameObjectsWithTag("Fast_Cars");
        fastcar = new Rigidbody[fastCars.Length];
        for (int i =0;i<fastCars.Length;++i)
        {
            GameObject fastCar = fastCars[i];
            fastcar[i] = fastCar.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Rigidbody car in fastcar) {
            Vector3 newPosition = car.transform.position+car.transform.forward*Time.deltaTime*speed;
            car.MovePosition(newPosition);
                }
    }
}
