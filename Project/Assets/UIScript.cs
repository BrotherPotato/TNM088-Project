using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    //public Image LegionImg1;
    //Image LegionImg1;
    GameObject legion1;
    GameObject legion2;
    GameObject legion3;
    GameObject legion4;
    Image LegionImg;
 

    public float opacity = 0.5f;
    public playerController playerScript;

    public Text ananasCounter;

    public int ananasCoin;

    public static bool legionar1Saved = false;
    public static bool legionar2Saved = false;
    public static bool legionar3Saved = false;
    public static bool legionar4Saved = false;

    //public float opacity;
    // Start is called before the first frame update
    void Start()
    {
        
        //LegionImg1 = GameObject.Find("Leg1");
        //LegionImg1 = leg1.GetComponent<Image>();
        legion1 = GameObject.Find("Leg1");
        legion2 = GameObject.Find("Leg2");
        legion3 = GameObject.Find("Leg3");
        legion4 = GameObject.Find("Leg4");
        
    }

    // Update is called once per frame
    void Update()
    {
        ananasCoin = playerScript.ananasCoin;
        ananasCounter.text = ananasCoin.ToString();

        //GetComponent<Image>();
        
        uppdateLegionRenderer(legionar1Saved, legion1);
        uppdateLegionRenderer(legionar2Saved, legion2);
        uppdateLegionRenderer(legionar3Saved, legion3);
        uppdateLegionRenderer(legionar4Saved, legion4);
    }
    
    void uppdateLegionRenderer (bool legionarSaved, GameObject legionNr)  {
        LegionImg = legionNr.GetComponent<Image>();

        var tempColor = LegionImg.color;
        if(legionarSaved)
        {
            tempColor.a = 1f;
        } else
        {
            tempColor.a = opacity;
        }
        LegionImg.color = tempColor;
    }
    
}
