using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public playerController playerScript;

    public Text ananasCounter;

    public int ananasCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ananasCoin = playerScript.ananasCoin;
        ananasCounter.text = ananasCoin.ToString();
    }
}
