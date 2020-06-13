using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    public GameObject effect;
    private AudioSource coinSource;
    
    // Start is called before the first frame update
    void Start()
    {
        coinSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bike")
        {
            coinSource.Play();
            Instantiate(effect,transform.position,transform.rotation);
        }
    }

}
