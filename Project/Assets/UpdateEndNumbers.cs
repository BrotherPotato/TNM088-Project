using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEndNumbers : MonoBehaviour
{

    public UIScript uiScript;
    //public Text timTimer;
    public Text poiPoints;
    // Start is called before the first frame update
    void Start()
    {
        poiPoints.text = uiScript.pointsText;
        //timTimer.text = uiScript.time;
    }

    // Update is called once per frame
    void Update()
    {
        //poiPoints.text = uiScript.pointsText;
        //timTimer.text = uiScript.time;
    }
}
