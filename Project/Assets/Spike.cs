using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Sprite active;
    public Sprite not_active;
    [SerializeField]
    public float timer;

    private bool activeState = true;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(switchState());

    }

    // Update is called once per frame
    void Update()
    {
        if(activeState)
        {
            spriteRenderer.sprite = active;
            transform.gameObject.tag = "Death"; 
        }
        else
        {
            spriteRenderer.sprite = not_active;
            transform.gameObject.tag = "ground";         
        }
    }
    IEnumerator switchState(){
    while(true)
    {
    yield return new WaitForSeconds(timer);
    activeState = !activeState;
    }
    }
}
