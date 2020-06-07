using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public static int noc;
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        noc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins:" + noc;
    }
}
