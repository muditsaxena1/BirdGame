using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    

    // Update is called once per frame
    
    void Update()
    {
        
        
    }

         void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Bike")
            {
            PlayerManager.noc += 1;
            Debug.Log("Coins:"+PlayerManager.noc);
                Destroy(gameObject);
              
        }
        }
    
}
