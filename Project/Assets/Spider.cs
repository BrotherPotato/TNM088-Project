using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    public float timer;
    public float timeBetween;

    public GameObject spiderWebPrefab;
    public GameObject player;
    public Transform playerTransform;
    [SerializeField]
    private float shootingRange;
    RaycastHit hit;
    private bool shooting = false;

    [SerializeField]
    private Vector3[] pos;

    private int index;

    void Start()
    {
        player = GameObject.Find("Player"); 
        playerTransform = player.transform;
    }

    void Update()
    {
        if(!shooting)
        transform.position = Vector2.MoveTowards(transform.position, pos[index], Time.deltaTime * speed);

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


 
        if(Vector2.Distance(transform.position, playerTransform.position) < shootingRange )
        {
            shooting = true;
            //StartCoroutine(shootingWebs());
            if(timeBetween <= 0f)
            {
                shootWeb();
                timeBetween = 3f; 
            }

        }
        else
        {
            shooting = false;
            //StopCoroutine(shootingWebs());
        }
        timeBetween -= Time.deltaTime;


    }
    IEnumerator shootingWebs()
    {
    while(shooting)
    {
    yield return new WaitForSeconds(timer);
    shootWeb();
    }
    }

    void shootWeb()
    {
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
