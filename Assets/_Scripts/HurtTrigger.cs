using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HurtTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject hurtOverlay;

    private void Start()
    {
        hurtOverlay = FindObjectOfType<CanvasManager>().GetHurtOverlay();
        if (!hurtOverlay)
        {
            Debug.Log("Nhi mila hurtOverlay");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bike")
        {
            if (hurtOverlay)
            {
                hurtOverlay.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Who the fuck is touching me nigga" + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bike")
        {
            if (hurtOverlay)
            {
                hurtOverlay.SetActive(false);
            }
        }
    }
}
