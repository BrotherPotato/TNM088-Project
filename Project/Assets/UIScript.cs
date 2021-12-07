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
    public Text timerTimer;
    public Text pointCounter;

    public int ananasCoin;

    //public float timeElapsed = 0f;
    public string time;
    private string timeTextMinutes;
    private string timeTextSeconds;
    private string pointsText;
    public int timeSecounds = 0;
    public int timeMinutes = 0;
    public int points = 1000;
    public static bool legionar1Saved = false;
    public static bool legionar2Saved = false;
    public static bool legionar3Saved = false;
    public static bool legionar4Saved = false;

    public bool kajjAlive = true;

    //playerController playerScript;
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
        
        StartCoroutine(secondCounter());
        
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

        //timeElapsed += Time.deltaTime;
        //int seconds = timeElapsed % 60;
        //timerTime.text = seconds.ToString();
    }
    
    void uppdateLegionRenderer (bool legionarSaved, GameObject legionNr)  
    {
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

    IEnumerator secondCounter()
    {
        while (kajjAlive)
        {
            timeCount();
            pointCount();
            yield return new WaitForSeconds(1);
        }
    }
    public void timeCount()
    {
        timeSecounds += 1;
        if(timeSecounds == 60)
        {
            timeMinutes += 1;
            timeSecounds = 1;
        }
        if(timeSecounds < 10)
        {
            timeTextSeconds = "0" + timeSecounds.ToString();
        } else
        {
            timeTextSeconds = timeSecounds.ToString();
        }
        if(timeMinutes < 10)
        {
            timeTextMinutes = "0" + timeMinutes.ToString();
        } else
        {
            timeTextMinutes = timeMinutes.ToString();
        }
        

        time = timeTextMinutes + ":" + timeTextSeconds;
        timerTimer.text = time;
    }
    
    public void pointCount()
    {
        points -= 5;
        if(points >= 10000)
        {
            pointsText = points.ToString() + "p";
        } else if(points >= 1000)
        {
            pointsText = "0" + points.ToString() + "p";
        } else if(points >= 100)
        {
            pointsText = "00" + points.ToString() + "p";
        } else if(points >= 10)
        {
            pointsText = "000" + points.ToString() + "p";
        } else if(points >= 0)
        {
            pointsText = "0000" + points.ToString() + "p";
        } else
        {
            playerScript.KillKajj();
        }
        //pointsText = points.ToString() + "p";
        pointCounter.text = pointsText;
    }
    public void touchAnanas()
    {
        points += 500;
    }
    public void touchLegion()
    {
        points += 5000;
    }
}
