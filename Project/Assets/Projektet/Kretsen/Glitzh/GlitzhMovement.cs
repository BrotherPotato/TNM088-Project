using UnityEngine;
using System.Collections;

public class GlitzhMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    SpriteRenderer sprite;
    public float speed;
    public int counter = 0;
    public int turn;
    public bool direction = true;


    // Use this for initialization
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    public void Update()
    {
        Move();
    }
    void Move() 
    { 
        counter++;
        if(turn == Mathf.Abs(counter)){
            if(speed > 0){
                sprite.flipX = true;
            }else{
                sprite.flipX = false;
            }
            speed = speed * -1;
            counter = 0;
        }
        animator.SetFloat("Speed", Mathf.Abs(speed)); 
        rb.velocity = new Vector2(-speed, rb.velocity.y); 
    }
}
