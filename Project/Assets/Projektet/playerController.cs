using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public GameObject ananasPrefab;
    public Animator animator;
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

    public int ananasCoin;
    public float moveBy;

    [SerializeField] private GameObject _RedParticlePrefab;
    [SerializeField] private GameObject DeatchCanvas;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();
        DeatchCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       Move();
       Jump();
       BetterJump();
       CheckIfGrounded();

       if (Input.GetMouseButtonDown(0) && ananasCoin > 0){
        shootAnanas();
        ananasCoin--;
       }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        //well code for restarting level or losing lifes depending on what we wanna do

        /*if(col.gameObject.tag == "bong"){
        Vector3 bongDir = (transform.position - col.gameObject.transform.position).normalized * 1f;

        rb.AddForce(bongDir * 1000f);
        }*/
        if(col.gameObject.tag == "boom")
        {
            Debug.Log(col.gameObject.tag);
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();

            if (Mathf.Abs(rb.velocity.x) > 1f)
            {
                Destroy(this.gameObject);

            }
        }
        if(col.gameObject.tag == "truck")
        {
            
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();


                Debug.Log("Death by box");
                Instantiate(_RedParticlePrefab, transform.position, Quaternion.identity);
                DeatchCanvas.SetActive(true);
                Destroy(this.gameObject);
                // döda kajj
            
        }

        if(col.gameObject.tag == "Coin"){
            ananasCoin++;
            Destroy(col.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "boom" || col.gameObject.tag == "truck")
        {
            
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();

            if (Mathf.Abs(rb.velocity.x) > 10f)
            {
                Debug.Log("Death by box");
                Instantiate(_RedParticlePrefab, transform.position, Quaternion.identity);
                DeatchCanvas.SetActive(true);
                Destroy(this.gameObject);
                // döda kajj
            }
        }
    }
    void shootAnanas()
    {
        GameObject s = Instantiate(ananasPrefab) as GameObject;
        s.transform.position = new Vector2(transform.position.x, transform.position.y);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (mousePos - transform.position);
        dir.z = 0.0f;
        Vector3 dirNormalized = dir.normalized;
        Debug.Log("pos: " + dirNormalized + "worldp: " + mousePos);

        Rigidbody2D rb = s.gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(s.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb.AddForce(dirNormalized * 1000f);
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
        moveBy = x * speed; 
        animator.SetFloat("Speed", Mathf.Abs(moveBy)); 
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
            animator.SetBool("IsJumping",  false);      
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
            animator.SetBool("IsJumping",  true); 
            
        } 
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            animator.SetBool("IsJumping",  true); 
        } 

    }
}
