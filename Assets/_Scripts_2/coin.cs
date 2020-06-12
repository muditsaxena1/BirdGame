using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public Component[] meshes;
    public GameObject effect;
    private AudioSource coinSource;

    void Start()
    {
        coinSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Update()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bike")
        {
            Instantiate(effect, transform.position, transform.rotation);
            meshes = GetComponentsInChildren<MeshRenderer>();

            PlayerManager.noc += 1;
            Debug.Log("Coins:" + PlayerManager.noc);
            foreach(MeshRenderer mesh in meshes)
            {
                mesh.enabled = false;
            }
            coinSource.Play();
            //Instantiate(effect, transform.position, transform.rotation);


        }
    }
}
