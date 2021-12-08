using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevelComp : MonoBehaviour
{

    public UIScript uiScript;

    public Text timTimer;
    public Text poiPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateNumbers()
    {
        poiPoints.text = uiScript.pointsText;
        timTimer.text = uiScript.time;
    }
}
