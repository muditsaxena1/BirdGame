using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private GameObject hurtOverlay;

    private void Awake()
    {
        hurtOverlay = GameObject.FindGameObjectWithTag("HurtOverlay");
        if (hurtOverlay)
            hurtOverlay.SetActive(false);
        else
            print("wtf");
    }

    public GameObject GetHurtOverlay()
    {
        return hurtOverlay;
    }
}
