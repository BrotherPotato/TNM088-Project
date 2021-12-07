using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScript : MonoBehaviour
{
    BoxCollider2D col;
    public Animator animator;
    public int counter = 0;
    public int zap;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
    void attack()
    {
        counter++;
        if(counter > zap){
            col.enabled = true;
            animator.SetBool("Attack", true);
            if(counter > (2*zap)){
                counter = 0;
                animator.SetBool("Attack", false);
                col.enabled = false;
            }
        }
    }
}
