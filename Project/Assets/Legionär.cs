using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legionär : MonoBehaviour
{
    FollowPlayer followplayer;

    public int legionNr;

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


            //UIScript.$"legionNr" = true;

            switch (legionNr)
            {
            case 1:
                Debug.Log("1");
                UIScript.legionar1Saved = true;
                break;

            case 2:
                Debug.Log("2");
                UIScript.legionar2Saved = true;
                break;

            case 3:
                Debug.Log("3");
                UIScript.legionar3Saved = true;
                break;

            case 4:
                Debug.Log("4");
                UIScript.legionar4Saved = true;
                break;
            
            default:
                Debug.Log("Unknown legionär found");
                break;
            }
        }
    }
}
