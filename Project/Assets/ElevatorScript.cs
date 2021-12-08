using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorScript : MonoBehaviour
{

    public UIScript uiScript;
    //public Sprite open;
    //public int legionNeeded;
    GameObject hissObject;

    public SpriteRenderer spriteRenderer;
    public Image hissSprite;
    public Sprite openHiss;

    public bool elevatorDoorOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        //hissObject = GameObject.Find("Elevator");
        //hissSprite = hissObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(legionär to be saved on this map)
        //change sprite to elevator open
        //ontriggerenter2d fade to black 0.5s then go next map
        
    }

    public void ActivateElevator()
    {
        elevatorDoorOpen = true;
        //hissObject = GameObject.Find("Elevator");
        //hissSprite = hissObject.GetComponent<Image>();
        //hissSprite.sprite = openHiss;
        spriteRenderer.sprite = openHiss;
        Debug.Log("active elev");
    }
}
