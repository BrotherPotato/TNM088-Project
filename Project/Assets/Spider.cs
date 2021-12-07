using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    public float timer;
    public float timeBetween = 0;

    public GameObject spiderWebPrefab;
    public GameObject player;
    public Transform playerTransform;
    [SerializeField]
    private float shootingRange;
    RaycastHit hit;
    public bool shooting = false;
    public bool finishShooting = false;
    public bool shootWeb = false;
    public Animator animator;

    [SerializeField]
    private Vector3[] pos;

    private int index;

    SpriteRenderer sprite;

    void Start()
    {
        player = GameObject.Find("Player"); 
        playerTransform = player.transform;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        animator.SetBool("Attacking", shooting);

        if(!shooting)
        transform.position = Vector2.MoveTowards(transform.position, pos[index], Time.deltaTime * speed);

        if(transform.position.x - pos[index].x < 0)
        sprite.flipX = true;
        else
        sprite.flipX = false;
        //transform.Rotate(Vector3.forward * -180 * Time.deltaTime);

        if(transform.position == pos[index])
        {

            if(index == pos.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }


 
        if(Vector2.Distance(transform.position, playerTransform.position) < shootingRange && timeBetween <= 0f)
        {
            shooting = true;
            timeBetween = 3f; 
        }
        animator.SetBool("Attacking", shooting);
        timeBetween -= Time.deltaTime;


    }
    IEnumerator shootingWebs()
    {
    while(shooting)
    {
    yield return new WaitForSeconds(timer);
    shootWebs();
    }
    }

    public void shootWebs()
    {
        //animator.SetBool("finishedShooting", false);
        finishShooting = false;

        GameObject s = Instantiate(spiderWebPrefab) as GameObject;
        s.transform.position = new Vector2(transform.position.x, transform.position.y);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (playerTransform.position - transform.position);
        dir.z = 0.0f;
        Vector3 dirNormalized = dir.normalized;
        Debug.Log("Shooting my shot");



        Rigidbody2D rb = s.gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(s.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb.AddForce(dirNormalized * 500f);
    }

}
