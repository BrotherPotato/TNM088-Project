using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public float speed;
    public float jumpheigth;
    bool isGrounded = false; 
    public Transform isGroundedChecker; 
    public float checkGroundRadius; 
    public LayerMask groundLayer;
    public float fallMultiplier = 9.82f; 
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor; 
    float lastTimeGrounded;
    public int defaultAdditionalJumps = 1; 
    int additionalJumps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       Move(); 
       Jump();
       BetterJump();
       CheckIfGrounded();
    }

    void Move() 
    { 
        float x = Input.GetAxisRaw("Horizontal"); 
        if(Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow)){
            sprite.flipX = true;
        }
        if(Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow)){
            sprite.flipX = false;
        }
        float moveBy = x * speed; 
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
    }

    void Jump() 
    { 
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpheigth);
            additionalJumps--;
            if(Input.GetKeyDown(KeyCode.Space) && !isGrounded && additionalJumps == 0){
                rb.gravityScale = 0.5f;
            }
         }
     } 

    void CheckIfGrounded()
    { 
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 
        if (colliders != null) { 
            isGrounded = true; 
            additionalJumps = defaultAdditionalJumps;
            rb.gravityScale = 1f;
        } 
        else 
        { 
            if (isGrounded) { 
                lastTimeGrounded = Time.time; 
            } 
            isGrounded = false; 
        } 
    }
    void BetterJump() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } 
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }
}
