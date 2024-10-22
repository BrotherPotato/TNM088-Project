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

    bool isAlive = true;
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

    public string deathBy;
    public Sprite deathSprite;
    public SpriteRenderer a;

    [SerializeField] private GameObject _RedParticlePrefab;
    [SerializeField] private GameObject DeatchCanvas;
    [SerializeField] private GameObject LevelCompletedCanvas;

    public PauseMenu pauseMenu;
    public UIScript uiScript;
    public UpdateLevelComp compCanvas;

    public AudioClip pickupCoin;
    public AudioClip death;
    public AudioClip jump;

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
        deathBy = col.gameObject.tag;
        //a = col.gameObject.GetComponent<SpriteRenderer>();
        deathSprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
        if(col.gameObject.tag == "Death"){
            GetComponent<AudioSource>().clip = death;
            GetComponent<AudioSource>().Play();
            KillKajj();
        }
        //KillKajj();
        if(col.gameObject.tag == "boom" && isAlive)
        {
            Debug.Log(col.gameObject.tag);
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            GetComponent<AudioSource>().clip = death;
            GetComponent<AudioSource>().Play();

            if (Mathf.Abs(rb.velocity.x) > 1f)
            {
                deathBy = col.gameObject.tag;
                        deathSprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;

                //Destroy(this.gameObject);
                //pauseMenu.DeathPause();
                KillKajj();
                //pauseMenu.DeathPause();

            }
        }
        if((col.gameObject.tag == "truck" || col.gameObject.tag == "ping" || col.gameObject.tag == "KillPlane") && isAlive)
        {
            
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            GetComponent<AudioSource>().clip = death;
            GetComponent<AudioSource>().Play();


                Debug.Log("Death by box");
                Instantiate(_RedParticlePrefab, transform.position, Quaternion.identity);
                DeatchCanvas.SetActive(true);
                //Destroy(this.gameObject);
                //pauseMenu.DeathPause();
                KillKajj();
                deathBy = col.gameObject.tag;
                deathSprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                //pauseMenu.DeathPause();
                // döda kajj
            
        }

        if(col.gameObject.tag == "Coin"){
            ananasCoin++;
            Destroy(col.gameObject);
            GetComponent<AudioSource>().clip = pickupCoin;
            GetComponent<AudioSource>().Play();
            uiScript.touchAnanas();
        }

        if(col.gameObject.tag == "elevator")
        {
            LevelCompletedCanvas.SetActive(true);
            compCanvas.updateNumbers();
            pauseMenu.DeathPause();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        deathSprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
        if((col.gameObject.tag == "boom" || col.gameObject.tag == "truck"  || col.gameObject.tag == "ping" ||  col.gameObject.tag == "KillPlane") && isAlive)
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();

            if (Mathf.Abs(rb.velocity.x) > 10f)
            {
                GetComponent<AudioSource>().clip = death;
                GetComponent<AudioSource>().Play();
                Debug.Log("Death by box");
                Instantiate(_RedParticlePrefab, transform.position, Quaternion.identity);
                DeatchCanvas.SetActive(true);
                KillKajj();
                deathBy = col.gameObject.tag;
                        deathSprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                //pauseMenu.DeathPause();   

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
            GetComponent<AudioSource>().clip = jump;
            GetComponent<AudioSource>().Play();
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

    public void KillKajj()
    {
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().isKinematic = true;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        uiScript.kajjAlive = false;
        jumpheigth = 0;
        speed = 0;
        pauseMenu.DeathSlowDown();
    }
}
