using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private AudioSource coinSource;
    public GameObject particleSys;
    public GameObject mesh;

    void Start()
    {
        coinSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Update()
    {


    }

    private void OnEnable()
    {
        particleSys.SetActive(false);
        mesh.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bike")
        {
            //Instantiate(effect, transform.position, transform.rotation);
            //meshes = GetComponentsInChildren<MeshRenderer>();

            PlayerManager.noc += 1;
            //Debug.Log("Coins:" + PlayerManager.noc);
            //foreach(MeshRenderer mesh in meshes)
            //{
            //    mesh.enabled = false;
            //}
            coinSource.Play();
            particleSys.SetActive(true);
            mesh.SetActive(false);
            //Instantiate(effect, transform.position, transform.rotation);


        }
    }
}
