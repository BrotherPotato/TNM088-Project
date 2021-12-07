using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCanvas : MonoBehaviour
{
    playerController _playerC;
    GameObject child;
    GameObject originalGameObject;

    public Sprite box;
    public Sprite truck;
    public Sprite ananas;

    public Sprite voidBlack;
    public Image spriteR;

    private string deathBy;
    // Start is called before the first frame update
    void Start()
    {
        _playerC = FindObjectOfType<playerController>();
        originalGameObject = GameObject.Find("DeathBackground");
        child = originalGameObject.transform.GetChild(0).gameObject;
        spriteR = child.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        deathBy = _playerC.deathBy;
        //0 truck, 1 box, 2

        if(deathBy == "truck"){
            child = GameObject.Find("DeathCanvasTruck");
            //originalGameObject.transform.GetChild(0).gameObject;
            //child.SetActive(true);
            spriteR.sprite = _playerC.deathSprite;
        }

        if(deathBy == "boom"){
            child = GameObject.Find("DeathCanvasBox");
            //originalGameObject.transform.GetChild(1).gameObject;
            //child.SetActive(true);
            spriteR.sprite = _playerC.deathSprite;
        }

        if(deathBy == "ping")
        {
            child = GameObject.Find("DeathCanvasAnanas");
            //originalGameObject.transform.GetChild(1).gameObject;
            //child.SetActive(true);
            spriteR.sprite = _playerC.deathSprite;
        }

        if(deathBy == "KillPlane")
        {
            //child = GameObject.Find("DeathCanvasAnanas");
            //originalGameObject.transform.GetChild(1).gameObject;
            //child.SetActive(true);
            //spriteR.sprite = _playerC.deathSprite;
        }
    }
}
