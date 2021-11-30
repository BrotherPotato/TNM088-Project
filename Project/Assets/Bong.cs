using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bong : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 bongDir;

    [SerializeField]
    private float bongForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        bongDir = (col.gameObject.transform.position - transform.position).normalized * bongForce;

        Debug.Log("yes");
        //inContact = true;
        rb = col.gameObject.GetComponent<Rigidbody2D>();

        rb.AddForce(bongDir * 1f);
        //rb.velocity = new Vector2(-1000f, rb.velocity.y); 
    }
    void OnCollisionExit2D(Collision2D col){
        Debug.Log("yes");
        //inContact = false;
        rb = col.gameObject.GetComponent<Rigidbody2D>();
    }
}
