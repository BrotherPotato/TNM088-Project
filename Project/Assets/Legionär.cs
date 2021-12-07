using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legionär : MonoBehaviour
{
    FollowPlayer followplayer;

    public int legionNr;

    public UIScript uiScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            followplayer = GetComponent<FollowPlayer>();
            followplayer.enabled = true;
            //uIScript.touchLegion();

            //UIScript.$"legionNr" = true;

            switch (legionNr)
            {
            case 1:
                if(!UIScript.legionar1Saved)
                {
                    Debug.Log("1");
                    UIScript.legionar1Saved = true;
                    uiScript.touchLegion();
                }
                break;

            case 2:
                if(!UIScript.legionar2Saved)
                {
                    Debug.Log("2");
                    UIScript.legionar2Saved = true;
                    uiScript.touchLegion();
                }
                break;

            case 3:
                if(!UIScript.legionar3Saved)
                {
                    Debug.Log("3");
                    UIScript.legionar3Saved = true;
                    uiScript.touchLegion();
                }
                break;

            case 4:
                if(!UIScript.legionar4Saved)
                {
                    Debug.Log("4");
                    UIScript.legionar4Saved = true;
                    uiScript.touchLegion();
                }
                break;
            
            default:
                Debug.Log("Unknown legionär found");
                break;
            }
        }
    }
}
